using Domain.Todos;

namespace DAL.EF.Todos;

public class TodoRepository : ITodoRepository
{
    public List<TodoItem> ReadAllTodos()
    {
        throw new NotImplementedException();
    }

    public TodoItem ReadTodoById(long id)
    {
        throw new NotImplementedException();
    }

    public TodoItem CreateTodo(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public TodoItem UpdateTodo(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public void DeleteTodo(long id)
    {
        throw new NotImplementedException();
    }
}