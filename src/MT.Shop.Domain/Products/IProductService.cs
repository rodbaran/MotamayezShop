using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Domain.Products;

public  interface IProductService
{
    Task<ProductDto> GetById (int id);

    Task<List<ProductDto>> GetListAsync();

    Task<List<ProductDto>> GetByName ( string name );
}
