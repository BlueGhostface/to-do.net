using Domain.User;

namespace DAL.EF.Users;

public interface IUserRepository
{
    //Read Create Update Delete
    
    public List<User> ReadAllUsers();
    
    public User ReadUserById(long id);
    
    public User CreateUser(User user);
    
    public User UpdateUser(User user);
    
    public void DeleteUser(long id);
    
}