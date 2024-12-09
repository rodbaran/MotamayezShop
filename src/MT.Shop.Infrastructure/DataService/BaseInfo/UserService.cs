using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.BaseInfo;
using MT.Shop.Domain.BaseInfo.Dto;
using MT.Shop.Infrastructure.DBContext;


namespace MT.Shop.Infrastructure.DataService.BaseInfo;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserDto>> GetAll()
    {
        var lst = await _dbContext.Users
             .Select(x => new UserDto(x))
             .AsNoTracking()
             .ToListAsync();

        return lst;

    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _dbContext.Users
            .Select(x => new UserDto(x))
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Id == id);

        if (user != null)
        {
            return user;
        }
        else
        {
            throw new Exception("کاربری با این شناسه یافت نشد");
        }
    }
}
