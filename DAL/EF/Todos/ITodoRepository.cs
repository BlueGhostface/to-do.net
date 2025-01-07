using Domain.Todos;

namespace DAL.EF.Todos;

public interface ITodoRepository
{
    //Read Create Update Delete
    
    public List<TodoItem> ReadAllTodos();
    
    public TodoItem ReadById(long id);
    
    public TodoItem Create(TodoItem todoItem);
    
    public TodoItem Update(TodoItem todoItem);
    
    public void Delete(long id);
}