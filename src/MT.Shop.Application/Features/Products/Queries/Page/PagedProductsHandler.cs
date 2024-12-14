using MediatR;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Products.Dto;
using MT.Shop.Domain.Helper.Types;


namespace MT.Shop.Application.Features.Products.Queries.Page;

public class PagedProductsHandler : IRequestHandler<GetPagedProductsQuery, PagedResult<ProductDto>>
{
    private readonly IProductService _service;

    public PagedProductsHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<PagedResult<ProductDto>> Handle(GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        var pagedResult = await _service.GetPagedProductsAsync(query,cancellationToken);

        return pagedResult;
    }
}

