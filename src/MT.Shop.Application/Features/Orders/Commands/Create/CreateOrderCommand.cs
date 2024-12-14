using MediatR;
using CSharpFunctionalExtensions;
using MT.Shop.Domain.Entities.Orders;

namespace MT.Shop.Application.Features.Orders.Commands.Create;

public class CreateOrderCommand : IRequest<Result>
{
    public int UserId { get; set; }
    public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}


