
using MediatR;
using MT.Shop.Domain.Products;
using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Application.Products.Queries.GerAll;

public class ListProductQueryHandler : IRequestHandler<ListProductsQuery, List<ProductDto>>
{
    private readonly IProductService _service;

    public ListProductQueryHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<List<ProductDto>> Handle(ListProductsQuery query, CancellationToken cancellationToken)
    {
       return await _service.GetListAsync();
    }
}
