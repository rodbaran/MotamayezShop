using MT.Shop.Domain.Entities.BaseEntities;

namespace MT.Shop.Domain.Entities.Products;

public class Product : SimpleEntity<int>
{
    public decimal Price { get; private set; }

    /// <summary>
    /// موجودی در دسترس 
    /// </summary>
    public int AvailableStock { get; private set; }



    public Product(int id, string code, string name, decimal price, int availableStock) : base()
    {
        Id = id;
        Code = code;
        Name = name;
        Price = price;
        AvailableStock = availableStock;
    }

    public void ReduceStock(int quantity)
    {
        AvailableStock -= quantity;
    }

    public void IncreaseStock(int quantity)
    {
        AvailableStock += quantity;
    }

}

