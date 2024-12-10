using MT.Shop.Domain.Helper.Types;
using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Domain.Products;

public  interface IProductService
{
    Task<ProductDto> GetById (int id);

    Task<List<ProductDto>> GetListAsync();

    Task<PagedResult<ProductDto>> GetPageAsync(PagedQueryBase query);

    Task<List<ProductDto>> GetByName ( string name );
}
