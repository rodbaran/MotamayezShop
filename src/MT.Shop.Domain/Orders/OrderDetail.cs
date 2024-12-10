using MT.Shop.Domain.BaseEntities;
using MT.Shop.Domain.Products;

namespace MT.Shop.Domain.Orders;

public class OrderDetail : BaseEntity<int>
{
    public OrderDetail()
    {
        
    }
    public OrderDetail(Product product, int quantity) : base()
    {
        Product = product ?? throw new ArgumentNullException(nameof(product));
        ProductId = product.Id;
        UnitPrice = product.Price;
        Quantity = quantity;

        product.ReduceStock(quantity);
    }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }

    public decimal TotalPrice => Quantity * UnitPrice;


    public void UpdateQuantity(int quantity)
    {
        if (quantity > Product.AvailableStock)
            throw new InvalidOperationException("Not enough stock available.");
        Product.IncreaseStock(Quantity); // بازگرداندن موجودی قبلی
        Quantity = quantity;
        Product.ReduceStock(quantity); // کاهش موجودی جدید
    }
}

