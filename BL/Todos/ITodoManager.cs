using Domain.Todos;

namespace BL.Todos;

public interface ITodoManager
{
    //Get Add Edit Remove
    public List<TodoItem> GetAllTodos();
    
    public TodoItem GetTodoById(long id);
    
    public TodoItem AddTodoItem(TodoItem todoItem);
    
    public TodoItem EditTodoItem(TodoItem todoItem);
    
    public void RemoveTodoItem(long id);
}