using MT.Shop.Domain.Users.Dto;

namespace MT.Shop.Domain.Users;

public interface IUserService
{
    Task<UserDto> GetById(int id);
    Task<List<UserDto>> GetAll();
}
