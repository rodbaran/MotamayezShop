using MediatR;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Domain.Products;
using MT.Shop.Domain.Products.Dto;

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
        var result = await _service.GetById(query.Id);

        return result;
    }
}
