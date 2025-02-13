using Domain.User;

namespace DAL.EF.Users;

public interface IUserRepository
{
    //Read Create Update Delete
    
    public List<User> ReadAllUsers();
    
    public User ReadUserById(Guid id);
    
    public void CreateUser(User user);
    
    public void UpdateUser(User user);
    
    public void DeleteUser(Guid id);
    
}