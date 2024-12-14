namespace MT.Shop.Domain.Entities.Users;
public interface IUserRepository
{
    Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> AnyAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);

    Task UpdateAsync(User user);

    void DeleteAsync(User user, CancellationToken cancellationToken);
}
