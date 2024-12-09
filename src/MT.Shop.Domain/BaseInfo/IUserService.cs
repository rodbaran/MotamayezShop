using MT.Shop.Domain.BaseInfo.Dto;

namespace MT.Shop.Domain.BaseInfo;

public interface IUserService
{
    Task<UserDto> GetById(int id);
    Task<List<UserDto>> GetAll();
}
