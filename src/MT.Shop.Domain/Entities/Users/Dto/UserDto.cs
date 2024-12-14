using MT.Shop.Domain.Entities.Users;

namespace MT.Shop.Domain.Entities.Users.Dto;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public UserDto(User user)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        PhoneNumber = user.PhoneNumber;
        Email = user.Email;
        Address = user.Address;
    }

}
