using MediatR;
using MT.Shop.Domain.Helper.Types;
using MT.Shop.Domain.Products;
using MT.Shop.Domain.Products.Dto;


namespace MT.Shop.Application.Features.Products.Queries.Page;

public class PageProductsHandler : IRequestHandler<PageProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductService _service;

    public PageProductsHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<PagedResult<ProductDto>> Handle(PageProductsQuery query, CancellationToken cancellationToken)
    {
        var pagedResult = await _service.GetPageAsync(query);

        return pagedResult;
    }
}

