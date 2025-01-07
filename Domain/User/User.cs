using Domain.Todos;

namespace Domain.User;

public class User
{

    public long Id;
    public string Name;
    public string Email;
    
    public ICollection<TodoItem> TodoItems { get; set; }
    
    public User()
    {
        
    }
    
    public User(string name, string email) : this()
    {
        Name = name;
        Email = email;
    }
    
}