using MediatR;
using MT.Shop.Domain.Entities.Products.Dto;
using MT.Shop.Domain.Helper.Types;
namespace MT.Shop.Application.Features.Products.Queries.Page;

public class GetPagedProductsQuery : PagedQueryBase, IRequest<PagedResult<ProductDto>>;
