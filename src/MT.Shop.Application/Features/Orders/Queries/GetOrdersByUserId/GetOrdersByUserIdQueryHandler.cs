using MediatR;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Exceptions;


namespace MT.Shop.Application.Features.Orders.Queries.GetOrdersByUserId;

public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, List<OrderDto>>
{
    private readonly IOrderService _service;

    public GetOrdersByUserIdQueryHandler(IOrderService service)
    {
        _service = service;
    }

    public async Task<List<OrderDto>> Handle(GetOrdersByUserIdQuery query, CancellationToken cancellationToken)
    {
        var orders = await _service.GetOrdersByUserIdAsync(query.UserId, cancellationToken);


        if (orders == null || orders.Count == 0)
            throw new NotFoundEntityException(string.Format(OrderErrors.OrderForUserNotFound, query.UserId));

        return orders;
    }
}
