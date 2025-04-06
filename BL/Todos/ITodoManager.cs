using Domain.Todos;
using Domain.User;

namespace BL.Todos;

public interface ITodoManager
{
    //Get Add Edit Remove
    public IEnumerable<TodoItem> GetAllTodos();
    
    public TodoItem GetTodoById(Guid id);
    
    public void AddTodoItem(string title, string description, StatusItem status, User user);
    
    public void AddTodoItem(TodoItem todoItem);
    
    public void EditTodoItem(Guid id,string title, string description, StatusItem status, User user);
    
    public void RemoveTodoItem(Guid id);
    
}