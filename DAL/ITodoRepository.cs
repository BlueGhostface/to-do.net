using Domain;

namespace DAL;

public interface ITodoRepository
{
    public List<TodoItem> ReadAllTodos();
}