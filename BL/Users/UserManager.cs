using DAL.EF.Users;
using Domain.User;

namespace BL.Users;

public class UserManager : IUserManager
{
    
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User GetUserById(long id)
    {
        throw new NotImplementedException();
    }

    public User AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public User EditUser(User user)
    {
        throw new NotImplementedException();
    }

    public void RemoveUser(long id)
    {
        throw new NotImplementedException();
    }
}