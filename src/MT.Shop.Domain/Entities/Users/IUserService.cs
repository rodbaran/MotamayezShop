using MT.Shop.Domain.Entities.Users.Dto;

namespace MT.Shop.Domain.Entities.Users;

public interface IUserService
{
    Task<UserDto> GeUserById(int id, CancellationToken cancellation);
    Task<List<UserDto>> GetListUsers(CancellationToken cancellation);
}
