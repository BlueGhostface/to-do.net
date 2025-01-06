using Domain;

namespace DAL;

public interface ITodoRepository
{
    //Read Create Update Delete
    
    public List<TodoItem> ReadAllTodos();
}