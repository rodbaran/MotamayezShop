using CSharpFunctionalExtensions;
using MediatR;
using MT.Shop.Application.Contracts;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Exceptions;



namespace MT.Shop.Application.Features.Orders.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderCommandHandler(IUnitOfWork uow)
    {
        _uow = uow ?? throw new NotFoundEntityException(nameof(uow));
    }

    public async Task<Result> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        //1.بررسی ورودی ها 
        if (command.OrderDetails == null || !command.OrderDetails.Any())
        {
            return Result.Failure(OrderErrors.EmptyOrderDetails);
        }

        var productIds = command.OrderDetails.Select(od => od.ProductId).ToList();

        //2. گرفتن اطلاعات محصولات مورد نیاز در یک درخواست
        var products = await _uow.ProductRepo.GetByIdsAsync(productIds);

        //3.لیست کاهای ناموجود 
        var insufficientStockProducts = new List<string>();

        foreach (var detail in command.OrderDetails)
        {
            var product = products.FirstOrDefault(p => p.Id == detail.ProductId);

            if (product == null)
            {
                return Result.Failure(string.Format(OrderErrors.ProductNotFound, detail.ProductId));
            }

            if (product.AvailableStock < detail.Quantity)
            {
                insufficientStockProducts.Add(product.Name);
                continue;
            }

            product.ReduceStock(detail.Quantity);
        }
        //4. در صورت داشتن کالای ناموجود ارسال لیست کالاهای نامجود و اتمام 
        if (insufficientStockProducts.Any())
        {
            return Result.Failure(string.Format(OrderErrors.InStockMultiple, string.Join(", ", insufficientStockProducts)));
        }

        // 5.به‌روزرسانی محصولات
        await _uow.ProductRepo.UpdateRangeAsync(products);

        // 6. ساخت و ذخیره سفارش
        var order = new Order(command.UserId, command.OrderDetails);
        await _uow.OrderRepo.AddAsync(order, cancellationToken);

        // 7.ذخیره تغییرات
        await _uow.CommitAsync(cancellationToken);

        return Result.Success(order);

    }
}


