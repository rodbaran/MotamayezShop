using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Orders;
using MT.Shop.Domain.Orders.Dto;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.DataService.Orders;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<OrderDto>> GetAllAsync()
    {
        var lst = await _dbContext.Orders
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Include(x => x.User)
            .Select(x => new OrderDto(x))
            .AsNoTracking()
            .ToListAsync();

        return lst;
    }

    public async Task<OrderDto> GetByIdAsync(int orderId)
    {
        var item = await _dbContext.Orders
            .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Include(x => x.User)
            .Select(x => new OrderDto(x))
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == orderId);

        return item ?? throw new Exception("رکوردی با این شناسه وجود ندارد");

    }

    public async Task<List<OrderDto>> GetOrderByUserId(int userId)
    {
        var lst = await _dbContext.Orders
                .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                .Include(x => x.User)
                .Select(x => new OrderDto(x))
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();

        return lst; 
    }
}
