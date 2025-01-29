using Domain.User;

namespace DAL.EF.Users;

public class UserRepository : IUserRepository
{
    private readonly TodoDbContext _context;
    
    public UserRepository(TodoDbContext context)
    {
        _context = context;
    }


    public List<User> ReadAllUsers()
    {
        throw new NotImplementedException();
    }

    public User ReadUserById(string id)
    {
        return _context.Users.Find(id) ?? throw new InvalidOperationException();
    }

    public User CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(string id)
    {
        throw new NotImplementedException();
    }
}