using MT.Shop.Domain.Entities.Products.Dto;
using MT.Shop.Domain.Helper.Types;

namespace MT.Shop.Domain.Entities.Products;

public interface IProductService
{
    Task<ProductDto> GetProductById(int id, CancellationToken cancellationToken);

    Task<List<ProductDto>> GetListProductsAsync(CancellationToken cancellationToken);

    Task<PagedResult<ProductDto>> GetPagedProductsAsync(PagedQueryBase query, CancellationToken cancellationToken);

    Task<List<ProductDto>> GetProductsByName(string name, CancellationToken cancellationToken);
}
