using MediatR;
using Microsoft.AspNetCore.Mvc;
using MT.Shop.Application.Common.Responses;

namespace MT.Shop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();



}
