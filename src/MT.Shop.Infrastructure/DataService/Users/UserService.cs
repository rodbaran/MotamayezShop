using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Entities.Users;
using MT.Shop.Domain.Entities.Users.Dto;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Infrastructure.DBContext;


namespace MT.Shop.Infrastructure.DataService.Users;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<UserDto>> GetListUsers(CancellationToken cancellation)
    {
        var lst = await _dbContext.Users
             .Select(x => new UserDto(x))
             .AsNoTracking()
             .ToListAsync(cancellation);

        return lst;

    }

    public async Task<UserDto> GeUserById(int id , CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Select(x => new UserDto(x))
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Id == id , cancellationToken);

        return user ?? throw new NotFoundEntityException();

    }

}
