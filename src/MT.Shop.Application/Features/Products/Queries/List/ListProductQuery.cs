using MediatR;
using MT.Shop.Application.Contracts;
using MT.Shop.Domain.Entities.Products.Dto;

namespace MT.Shop.Application.Features.Products.Queries.List;

public class ListProductsQuery : IRequest<List<ProductDto>>, ICacheQuery
{
    public int HoursSaveData => 1;
}
