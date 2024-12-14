using MT.Shop.Domain.Entities.BaseEntities;

namespace MT.Shop.Domain.Entities.Users;
public class User : BaseEntity<int>
{
    public User(int id, string firstName, string lastName, string phoneNumber, string email, string address) : base()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
    }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }


}
