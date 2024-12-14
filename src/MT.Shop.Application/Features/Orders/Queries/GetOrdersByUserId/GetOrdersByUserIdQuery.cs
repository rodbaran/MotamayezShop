using MediatR;
using MT.Shop.Domain.Entities.Orders.Dto;

namespace MT.Shop.Application.Features.Orders.Queries.GetOrdersByUserId;

public record GetOrdersByUserIdQuery(int UserId) : IRequest<List<OrderDto>>;
