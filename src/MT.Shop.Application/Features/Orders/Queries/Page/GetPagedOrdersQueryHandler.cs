using MediatR;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Helper.Types;


namespace MT.Shop.Application.Features.Orders.Queries.Page;

public class GetPagedOrdersQueryHandler : IRequestHandler<GetPagedOrdersQuery, PagedResult<OrderDto>>
{
    private readonly IOrderService _service;

    public GetPagedOrdersQueryHandler(IOrderService service)
    {
        _service = service;
    }

    public async Task<PagedResult<OrderDto>> Handle(GetPagedOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageResult = await _service.GetPagedOrdersAsync(query, cancellationToken);

        return pageResult;
    }
}
