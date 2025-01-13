using System.ComponentModel.DataAnnotations;
using Domain.Todos;

namespace Domain.User;

public class User
{

    [Key]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }

    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    
    public User()
    {
        
    }
    
    public User(string name, string email, long id) : this()
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
}