using MT.Shop.Domain.Entities.BaseEntities;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Users;
using MT.Shop.Domain.Enums;
using MT.Shop.Domain.Exceptions;

namespace MT.Shop.Domain.Entities.Orders;
/// <summary>
/// سفارشات 
/// </summary>
public class Order : BaseEntity<int>
{
    public Order()
    {
        
    }
    public Order(int userId, List<OrderDetail> orderDetails)
    {
        UserId = userId;
        CreatedOn = DateTime.Now;
        CreatedBy = userId;
        Status = OrderStatus.Confirmed;
        orderDetails = orderDetails ?? new List<OrderDetail>();
    }
    public int UserId { get; private set; }
    public User User { get; set; }

    public OrderStatus Status { get; private set; } = OrderStatus.Draft;
    public List<OrderDetail> OrderDetails { get; private set; } = new();

    public decimal TotalAmount => OrderDetails.Sum(od => od.TotalPrice);

    public int GetProductQuantity(int productId)
    {
        return OrderDetails.FirstOrDefault(od => od.ProductId == productId)?.Quantity ?? 0;
    }

    public void ConfirmOrder()
    {
        if (Status != OrderStatus.Draft)
            throw new BadRequestEntityException(OrderErrors.DraftOnlyApprovable);

        Status = OrderStatus.Confirmed;
    }

    public void CancelOrder()
    {
        if (Status == OrderStatus.Canceled)
            throw new BadRequestEntityException(OrderErrors.OrderAlreadyCanceled);

        foreach (var detail in OrderDetails)
        {
            detail.Product.IncreaseStock(detail.Quantity);
        }

        Status = OrderStatus.Canceled;
    }

    public void EditOrder(List<(Product product, int quantity)> updates)
    {
        if (Status != OrderStatus.Draft)
            throw new BadRequestEntityException(OrderErrors.DraftOnlyApprovable);

        foreach (var update in updates)
        {
            var existingDetail = OrderDetails.FirstOrDefault(od => od.ProductId == update.product.Id);

            if (existingDetail != null)
            {
                existingDetail.UpdateQuantity(update.quantity);
            }
            else
            {
                OrderDetails.Add(new OrderDetail(update.product, update.quantity));
            }
        }
    }
}
