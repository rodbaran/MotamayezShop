using MediatR;
using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Application.Features.Products.Queries.List;

public record ListProductsQuery : IRequest<List<ProductDto>>;