using MediatR;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Products.Dto;

namespace MT.Shop.Application.Features.Products.Queries.Get;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductService _service;

    public GetProductQueryHandler(IProductService service)
    {
        _service = service;
    }

    public async Task<ProductDto> Handle(GetProductQuery query, CancellationToken cancellationToken)
    {
        var result = await _service.GetProductById(query.Id , cancellationToken);

        return result;
    }
}
