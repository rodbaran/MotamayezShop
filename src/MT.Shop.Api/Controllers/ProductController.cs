using Microsoft.AspNetCore.Mvc;
using MT.Shop.Application.Features.Products.Queries.Get;
using MT.Shop.Application.Features.Products.Queries.List;
using MT.Shop.Application.Features.Products.Queries.Page;
using MT.Shop.Domain.Entities.Products.Dto;
using MT.Shop.Domain.Helper.Types;


namespace MT.Shop.Api.Controllers;

public class ProductController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetListProducts([FromQuery] ListProductsQuery query , CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProductById([FromRoute] int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetProductQuery(id), cancellationToken));
    }

    [HttpPost("products")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<ProductDto>>> GetPagedProducts([FromBody] GetPagedProductsQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }
}
