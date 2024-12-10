using Microsoft.AspNetCore.Mvc;
using MT.Shop.Application.Products.Queries.GerAll;
using MT.Shop.Application.Products.Queries.Get;
using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Api.Controllers;

public class ProductController : BaseController
{
    [HttpGet]

    public async Task<ActionResult<IEnumerable<ProductDto>>> Get([FromQuery] ListProductsQuery query , CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetProductQuery(id), cancellationToken));
    }
}
