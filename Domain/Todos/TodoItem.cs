using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Todos;

using User;

public class TodoItem
{
    [Key] public Guid Id { get; set; }
    [Required] public string Title { get; set; } = "";
    [Required] public string Description { get; set; } = "";
    [Required] public StatusItem StatusItem { get; set; } = StatusItem.OPEN;
   
    
    [ForeignKey("UserId")]
    public string UserId { get; set; }
    public User User { get; set; }

    public TodoItem()
    {
        
    }


    public TodoItem(string title, string description, StatusItem statusItem, User user) : this()
    {
        Title = title;
        Description = description;
        StatusItem = statusItem;
        UserId = user.Id;
        User = user;
    }
}