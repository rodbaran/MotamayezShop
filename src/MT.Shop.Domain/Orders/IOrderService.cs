using MT.Shop.Domain.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Shop.Domain.Orders;

public interface IOrderService
{
    // دریافت سفارش همراه جزییات با id
    Task<OrderDto> GetByIdAsync(int orderId);


    //دریافت سفارشات همراه با جزییات 
    Task<List<OrderDto>> GetAllAsync();


    // دریافت سفارشات همراه با جزییات بر اساس کاربر
    Task<List<OrderDto>> GetOrderByUserId (int userId);


}
