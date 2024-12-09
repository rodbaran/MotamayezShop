using MT.Shop.Domain.Products.Dto;

namespace MT.Shop.Domain.Products;

public  interface IProductService
{
    Task<ProductDto> GetById (int id);

    Task<List<ProductDto>> GetAll();

    Task<List<ProductDto>> GetByName ( string name );
}
