using MediatR;
using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Application.Products.Queries.GerAll;

public record ListProductsQuery : IRequest<List<ProductDto>>;