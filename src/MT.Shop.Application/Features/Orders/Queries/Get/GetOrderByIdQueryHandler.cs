using MediatR;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Exceptions;


namespace MT.Shop.Application.Features.Orders.Queries.Get;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    private readonly IOrderService _service;

    public GetOrderByIdQueryHandler(IOrderService service)
    {
        _service = service;
    }

    public async Task<OrderDto> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
    {
        var item = await _service.GetOrderByIdAsync(query.OrderId , cancellationToken);

        return item ?? throw new NotFoundEntityException();
    }
}
