using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Orders.Dto;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Domain.Helper;
using MT.Shop.Domain.Helper.Types;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.DataService.Orders;

public sealed class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<OrderDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Orders
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Include(x => x.User)
            .AsNoTracking()
            .Where(x => x.Id == orderId)
            .Select(x => new OrderDto(x))
            .FirstOrDefaultAsync(cancellationToken);

        if (item == null)
            throw new NotFoundEntityException(OrderErrors.Required);

        return item;
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Include(x => x.User)
            .AsNoTracking()
            .Select(x => new OrderDto(x))
            .ToListAsync(cancellationToken);
    }

    public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Include(x => x.User)
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Select(x => new OrderDto(x))
            .ToListAsync(cancellationToken);
    }

    public async Task<PagedResult<OrderDto>> GetPagedOrdersAsync(PagedQueryBase query, CancellationToken cancellationToken)
    {
        return await _dbContext.Orders
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Include(x => x.User)
            .AsNoTracking()
            .Select(x => new OrderDto(x))
            .PaginateAsync(query, cancellationToken);
    }
}

