using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Enums;

namespace MT.Shop.Domain.Entities.Orders.Dto;

public class OrderDto
{
    private readonly List<OrderDetailDto> _orderDetail = new List<OrderDetailDto>();
    public int Id { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; }

    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }
    public virtual IEnumerable<OrderDetailDto> OrderDetailDto => _orderDetail;
    public OrderDto(Order order)
    {
        Id = order.Id;
        UserId = order.UserId;
        UserName = order.User.FirstName + " " + order.User.LastName;
        TotalAmount = order.TotalAmount;
        Status = order.Status;
        foreach (var orderDetail in order.OrderDetails)
            _orderDetail.Add(new OrderDetailDto(orderDetail));
    }

}
