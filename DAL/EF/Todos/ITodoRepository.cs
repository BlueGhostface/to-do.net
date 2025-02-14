using Domain.Todos;

namespace DAL.EF.Todos;

public interface ITodoRepository
{
    //Read Create Update Delete
    
    public IEnumerable<TodoItem> ReadAllTodos();
    
    public TodoItem ReadTodoById(Guid id);
    
    public void CreateTodo(TodoItem todoItem);
    
    public void UpdateTodo(TodoItem todoItem);
    
    public void DeleteTodo(TodoItem todoItem);
    
    public void DeleteTodoById(Guid id);
}