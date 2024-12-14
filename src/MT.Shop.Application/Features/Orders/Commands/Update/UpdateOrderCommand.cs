using CSharpFunctionalExtensions;
using MediatR;
using MT.Shop.Domain.Entities.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MT.Shop.Application.Features.Orders.Commands.Update;

public class UpdateOrderCommand : IRequest<Result>
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
}
