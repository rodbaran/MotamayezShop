using CSharpFunctionalExtensions;
using MediatR;
using MT.Shop.Application.Contracts;
using MT.Shop.Domain.Entities.Orders;

namespace MT.Shop.Application.Features.Orders.Commands.Update;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderCommandHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
    }

    public async Task<Result> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        // 1. بررسی ورودی‌ها
        if (command.OrderDetails == null || !command.OrderDetails.Any())
        {
            return Result.Failure(OrderErrors.EmptyOrderDetails);
        }

        // 2. بازیابی سفارش
        var order = await _uow.OrderRepo.GetByIdAsync(command.OrderId, cancellationToken);
        if (order == null)
        {
            return Result.Failure(string.Format(OrderErrors.OrderNotFound, command.OrderId));
        }

        // 3. بررسی مالکیت سفارش
        if (order.UserId != command.UserId)
        {
            return Result.Failure(OrderErrors.NotAuthorized);
        }

        // 4. بازیابی اطلاعات محصولات
        var productIds = command.OrderDetails.Select(od => od.ProductId).ToList();
        var products = await _uow.ProductRepo.GetByIdsAsync(productIds);

        var insufficientStockProducts = new List<string>();

        // 5. بررسی موجودی محصولات
        foreach (var detail in command.OrderDetails)
        {
            var product = products.FirstOrDefault(p => p.Id == detail.ProductId);
            if (product == null)
            {
                return Result.Failure(string.Format(OrderErrors.ProductNotFound, detail.ProductId));
            }

            if (product.AvailableStock + order.GetProductQuantity(detail.ProductId) < detail.Quantity)
            {
                insufficientStockProducts.Add(product.Name);
            }
        }

        // 6. ارسال خطا در صورت موجودی ناکافی
        if (insufficientStockProducts.Any())
        {
            return Result.Failure(string.Format(OrderErrors.InStockMultiple, string.Join(", ", insufficientStockProducts)));
        }

        // 7. به‌روزرسانی موجودی محصولات
        foreach (var detail in command.OrderDetails)
        {
            var product = products.First(p => p.Id == detail.ProductId);
            product.ReduceStock(detail.Quantity - order.GetProductQuantity(detail.ProductId));
        }

        await _uow.ProductRepo.UpdateRangeAsync(products);

        // 8. به‌روزرسانی سفارش
        order.EditOrder(command.OrderDetails.Select(od => (products.First(p => p.Id == od.ProductId), od.Quantity)).ToList());

        // 9. ذخیره تغییرات
        await _uow.CommitAsync(cancellationToken);

        return Result.Success(order);
    }
}
