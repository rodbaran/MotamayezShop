using MT.Shop.Domain.BaseEntities;
using MT.Shop.Domain.BaseInfo;
using MT.Shop.Domain.Enums;
using MT.Shop.Domain.Products;

namespace MT.Shop.Domain.Orders;
/// <summary>
/// سفارشات 
/// </summary>
public class Order : BaseEntity<int>
{
    public Order()
    {
        
    }
    public Order(int userId , List<OrderDetail> orderDetails)
    {
        UserId = userId;
        orderDetails = OrderDetails;
    }
    public  int UserId { get; private set; }
    public User User { get;  set; }

    public OrderStatus Status { get; private set; } = OrderStatus.Draft;
    public List<OrderDetail> OrderDetails { get; private set; } = new();

    public decimal TotalAmount => OrderDetails.Sum(od => od.TotalPrice);


    public void ConfirmOrder()
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("فقط فاکتور های با وضیعت پیش نویس قابلیت تایید شدن دارند ");

        Status = OrderStatus.Confirmed;
    }

    public void CancelOrder()
    {
        if (Status == OrderStatus.Canceled )
            throw new InvalidOperationException("سفارش شما در وضیعت ابطال می باشد و نیازی به ابطال آن نیست");
        if (Status == OrderStatus.Confirmed)
            throw new InvalidOperationException("سفارش شما در وضیعت تایید می باشد و امکان ابطال آن وجود ندارد");

        foreach (var detail in OrderDetails)
        {
            detail.Product.IncreaseStock(detail.Quantity);
        }

        Status = OrderStatus.Canceled;
    }

    public void EditOrder(List<(Product product, int quantity)> updates)
    {
        if (Status != OrderStatus.Draft)
            throw new InvalidOperationException("Only draft orders can be edited.");

        foreach (var update in updates)
        {
            var existingDetail = OrderDetails.FirstOrDefault(od => od.ProductId == update.product.Id);

            if (existingDetail != null)
            {
                existingDetail.UpdateQuantity(update.quantity);
            }
            else
            {
                var newDetail = new OrderDetail(update.product, update.quantity);
                OrderDetails.Add(newDetail);
            }
        }
    }
}
