using MT.Shop.Domain.Entities.Products;

namespace MT.Shop.Domain.Entities.Products.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; }

    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public decimal Price { get; set; }

    public int AvailableStock { get; set; }


    public ProductDto(Product product)
    {
        Id = product.Id;
        Code = product.Code;
        Name = product.Name;
        IsActive = product.IsActive;
        Price = product.Price;
        AvailableStock = product.AvailableStock;
    }
}
