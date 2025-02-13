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
        return _context.Users.ToList();
    }

    public User ReadUserById(Guid id)
    {
        return _context.Users.Find(id) ?? throw new InvalidOperationException();
    }

    public void CreateUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges(); 
    }

    public void UpdateUser(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void DeleteUser(Guid id)
    {
        var user = ReadUserById(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}