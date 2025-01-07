using Domain.Todos;

namespace DAL.EF.Todos;

public class TodoRepository : ITodoRepository
{
    public List<TodoItem> ReadAllTodos()
    {
        throw new NotImplementedException();
    }

    public TodoItem ReadById(long id)
    {
        throw new NotImplementedException();
    }

    public TodoItem Create(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public TodoItem Update(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }
}