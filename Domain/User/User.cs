using System.ComponentModel.DataAnnotations;
using Domain.Todos;
using Microsoft.AspNetCore.Identity;

namespace Domain.User;

public class User : IdentityUser
{
    
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }

    public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    
    public User()
    {
    }
    
    public User(string name, string email) : this()
    {
        Name = name;
        Email = email;
    }
    
}