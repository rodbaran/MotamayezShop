using MT.Shop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Shop.Domain.Entities.Orders.Dto;

public class OrderDetailDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductCode { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }


    public OrderDetailDto(OrderDetail orderDetail)
    {
        Id = orderDetail.Id;
        OrderId = orderDetail.OrderId;
        ProductId = orderDetail.ProductId;
        ProductName = orderDetail?.Product?.Name;
        ProductCode = orderDetail?.Product?.Code;
        Quantity = orderDetail.Quantity;
        UnitPrice = orderDetail.UnitPrice;
        TotalPrice = Quantity * UnitPrice;
    }

}
