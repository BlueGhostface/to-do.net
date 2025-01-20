using Domain.Todos;

namespace DAL.EF.Todos;

public interface ITodoRepository
{
    //Read Create Update Delete
    
    public IEnumerable<TodoItem> ReadAllTodos();
    
    public TodoItem ReadTodoById(long id);
    
    public TodoItem CreateTodo(TodoItem todoItem);
    
    public TodoItem UpdateTodo(TodoItem todoItem);
    
    public void DeleteTodo(long id);
}