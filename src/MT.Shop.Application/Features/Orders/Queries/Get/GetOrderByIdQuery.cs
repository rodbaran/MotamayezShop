using MediatR;
using MT.Shop.Domain.Entities.Orders.Dto;

namespace MT.Shop.Application.Features.Orders.Queries.Get;

public record GetOrderByIdQuery (int OrderId) : IRequest<OrderDto>;
