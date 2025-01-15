using Domain.User;

namespace DAL.EF.Users;

public class UserRepository : IUserRepository
{
    public List<User> ReadAllUsers()
    {
        throw new NotImplementedException();
    }

    public User ReadUserById(long id)
    {
        throw new NotImplementedException();
    }

    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(long id)
    {
        throw new NotImplementedException();
    }
}