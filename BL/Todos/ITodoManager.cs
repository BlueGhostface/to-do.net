using Domain.Todos;
using Domain.User;

namespace BL.Todos;

public interface ITodoManager
{
    //Get Add Edit Remove
    public IEnumerable<TodoItem> GetAllTodos();
    
    public TodoItem GetTodoById(long id);
    
    public void AddTodoItem(string description, StatusItem status, User user);
    
    public void EditTodoItem(TodoItem todoItem);
    
    public void RemoveTodoItem(long id);
    
}