using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Infrastructure.DBContext;


namespace MT.Shop.Infrastructure.EFRepositories.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Order Order, CancellationToken cancellationToken)
         => await _dbContext.AddAsync(Order, cancellationToken);

    public async Task<bool> AnyAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.Orders.AnyAsync(x => x.Id == id, cancellationToken);

    public async void DeleteAsync(Order order, CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(order.Id, cancellationToken);
        record.IsDelete = true;
        await UpdateAsync(order);
    }

    public async Task<Order> GetByIdAsync(int id, CancellationToken cancellationToken)
    => await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundEntityException();

    public async Task UpdateAsync(Order order)
    => await Task.Run(() => _dbContext.Update(order));
}
