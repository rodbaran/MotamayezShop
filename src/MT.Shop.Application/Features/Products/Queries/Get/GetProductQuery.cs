using MediatR;
using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Application.Features.Products.Queries.Get;

public record GetProductQuery(int Id) : IRequest<ProductDto>;

