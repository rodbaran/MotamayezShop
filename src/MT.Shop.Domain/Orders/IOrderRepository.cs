namespace MT.Shop.Domain.Orders;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> AnyAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Order order, CancellationToken cancellationToken);
    Task UpdateAsync(Order order);
    void DeleteAsync(Order order, CancellationToken cancellationToken);
}
