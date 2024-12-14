using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Entities.Users;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.EFRepositories.Users;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user, CancellationToken cancellationToken)
        => await _dbContext.AddAsync(user, cancellationToken);


    public async Task<bool> AnyAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.Users.AnyAsync(x => x.Id == id, cancellationToken);


    public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new NotFoundEntityException();


    public async void DeleteAsync(User user, CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(user.Id, cancellationToken);
        record.IsDelete = true;
        await UpdateAsync(user);

    }

    public async Task UpdateAsync(User user)
    => await Task.Run(() => _dbContext.Update(user));
}
