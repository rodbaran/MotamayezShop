using MT.Shop.Domain.Entities.BaseEntities;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Exceptions;

namespace MT.Shop.Domain.Entities.Orders;

public class OrderDetail : BaseEntity<int>
{
    public OrderDetail()
    {
        
    }
    public OrderDetail(Product product, int quantity)
    {
        Product = product;
        ProductId = product.Id;
        UnitPrice = product.Price;
        Quantity = quantity;
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
            throw new ValidationEntityException(OrderErrors.InsufficientStock);
        Product.IncreaseStock(Quantity); // بازگرداندن موجودی قبلی
        Quantity = quantity;
        Product.ReduceStock(quantity); // کاهش موجودی جدید
    }
}

