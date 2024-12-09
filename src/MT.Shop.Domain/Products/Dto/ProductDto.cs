namespace MT.Shop.Domain.Products.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string Code { get; set; }

    public string Name { get; set; }
    public bool IsActive { get; set; }

    public string IsActiveText { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }


    public ProductDto(Product product)
    {
        Id = product.Id;
        Code = product.Code;
        Name = product.Name;
        IsActive = product.IsActive;
        IsActiveText = product.IsActive ? "فعال" : "غیر فعال";
        Price = product.Price;
        AvailableStock = product.AvailableStock;
    }
}
