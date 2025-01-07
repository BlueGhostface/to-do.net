namespace Domain.Todos;

using User;

public class TodoItem
{
    public long Id { get; set; }
    public string Description { get; set; } = "";
    public StatusItem StatusItem { get; set; } = StatusItem.OPEN;

   public User User { get; set; }

    public TodoItem()
    {
        
    }

    public TodoItem(string description, StatusItem statusItem, User user) : this()
    {
        Description = description;
        StatusItem = statusItem;
        User = user;
    }
    
    
}