using MT.Shop.Domain.BaseEntities;

namespace MT.Shop.Domain.Products;

public class Product : SimpleEntity<int>
{
    public decimal Price { get; private set; }

    /// <summary>
    /// موجودی در دسترس 
    /// </summary>
    public int AvailableStock { get; private set; }



    public Product(string code, string name, decimal price, int availableStock)
    {
        Code = code;
        Name = name;
        Price = price;
        AvailableStock = availableStock;
    }

    public void ReduceStock(int quantity)
    {
        if (quantity > AvailableStock)
        {
            throw new InvalidOperationException("Not enough stock available.");
        }
        AvailableStock -= quantity;
    }

    public void IncreaseStock(int quantity)
    {
        AvailableStock += quantity;
    }

}

