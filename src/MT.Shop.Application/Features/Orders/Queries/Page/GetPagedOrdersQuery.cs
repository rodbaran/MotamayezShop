using MediatR;
using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Helper.Types;

namespace MT.Shop.Application.Features.Orders.Queries.Page;

public class GetPagedOrdersQuery : PagedQueryBase , IRequest<PagedResult<OrderDto>>;
