using Domain.Todos;
using Domain.User;

namespace BL.Todos;

public interface ITodoManager
{
    //Get Add Edit Remove
    public List<TodoItem> GetAllTodos();
    
    public TodoItem GetTodoById(long id);
    
    public TodoItem AddTodoItem(string description, StatusItem status, User user);
    
    public TodoItem EditTodoItem(TodoItem todoItem);
    
    public void RemoveTodoItem(long id);
}