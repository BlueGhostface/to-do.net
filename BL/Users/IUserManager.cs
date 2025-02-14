using Domain.User;

namespace BL.Users;

public interface IUserManager
{
    public List<User> GetAllUsers();
    
    public User GetUserById(string id);
    
    public User AddUser(User user);
    
    public User EditUser(User user);
    
    public void RemoveUser(Guid id);
}