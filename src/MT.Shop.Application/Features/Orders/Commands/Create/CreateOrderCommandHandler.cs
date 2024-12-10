using CSharpFunctionalExtensions;
using MediatR;
using MT.Shop.Application.Contracts;
using MT.Shop.Domain.Orders;


namespace MT.Shop.Application.Features.Orders.Commands.Create;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Result> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        foreach (var detail in command.OrderDetails)
        {
            var product = await _uow.ProductRepo.GetByIdAsync(detail.ProductId);
            if (product == null || product.AvailableStock < detail.Quantity)
            {
                return Result.Failure($"Product {detail.ProductId} is out of stock.");
            }

            product.ReduceStock(detail.Quantity);
            await _uow.ProductRepo.UpdateAsync(product);
        }

        var order = new Order(command.UserId,command.OrderDetails);
        
        await _uow.OrderRepo.AddAsync(order , cancellationToken);
        await _uow.CommitAsync(cancellationToken);
        return Result.Success(order);

    }
}
