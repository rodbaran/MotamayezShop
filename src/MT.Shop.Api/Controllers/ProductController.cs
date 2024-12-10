using Microsoft.AspNetCore.Mvc;
using MT.Shop.Application.Products.Queries.GerAll;
using MT.Shop.Application.Products.Queries.Get;
using MT.Shop.Application.Products.Queries.Page;
using MT.Shop.Domain.Helper.Types;
using MT.Shop.Domain.Products.Dto;


namespace MT.Shop.Api.Controllers;

public class ProductController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetList([FromQuery] ListProductsQuery query , CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> Get([FromRoute] int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetProductQuery(id), cancellationToken));
    }

    [HttpPost("products")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<ProductDto>>> GetPage([FromBody] PageProductsQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }
}
