using Microsoft.AspNetCore.Mvc;
using MT.Shop.Application.Features.Orders.Commands.Create;
using MT.Shop.Application.Features.Orders.Queries.Get;
using MT.Shop.Application.Features.Orders.Queries.GetOrdersByUserId;
using MT.Shop.Application.Features.Orders.Queries.Page;
using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Helper.Types;

namespace MT.Shop.Api.Controllers;

public class OrderController : BaseController
{
    [HttpGet("order/{id:int}")]
    public async Task<ActionResult<OrderDto>> GetOrderById([FromRoute] int id, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetOrderByIdQuery(id), cancellationToken));
    }

    [HttpPost("PagedOrders")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PagedResult<OrderDto>>> GetPage([FromBody] GetPagedOrdersQuery query, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(query, cancellationToken));
    }

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<OrderDto>> GetOrdersByUserId([FromRoute] int userId, CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetOrdersByUserIdQuery(userId), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<IActionResult> CreateAsync(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var commandResult = await Mediator.Send(command , cancellationToken);

        if (commandResult.IsSuccess)
            return Ok();
        else
        {
            return BadRequest(commandResult.Error);
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<IActionResult> EditAsync(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var commandResult = await Mediator.Send(command, cancellationToken);

        if (commandResult.IsSuccess)
            return Ok();
        else
        {
            return BadRequest(commandResult.Error);
        }
    }

}
