namespace Domain;

public class TodoItem
{
    public int Id { get; set; }
    public string Description { get; set; } = "";
    public StatusItem StatusItem { get; set; } = StatusItem.OPEN;

    public TodoItem()
    {
        
    }

    public TodoItem(string description, StatusItem statusItem) : this()
    {
        Description = description;
        StatusItem = statusItem;
    }
    
    
}