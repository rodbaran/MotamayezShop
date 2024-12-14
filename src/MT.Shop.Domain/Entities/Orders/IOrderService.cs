using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Helper.Types;

namespace MT.Shop.Domain.Entities.Orders;

public interface IOrderService
{
    Task<OrderDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken);

    Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken);

    Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken);

    Task<PagedResult<OrderDto>> GetPagedOrdersAsync(PagedQueryBase paginationQuery, CancellationToken cancellationToken);
}