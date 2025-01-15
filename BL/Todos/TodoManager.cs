using DAL.EF.Todos;
using Domain.Todos;

namespace BL.Todos;

public class TodoManager : ITodoManager
{
    
    private readonly ITodoRepository _todoRepository;

    public TodoManager(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public List<TodoItem> GetAllTodos()
    {
        throw new NotImplementedException();
    }

    public TodoItem GetTodoById(long id)
    {
        throw new NotImplementedException();
    }

    public TodoItem AddTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public TodoItem EditTodoItem(TodoItem todoItem)
    {
        throw new NotImplementedException();
    }

    public void RemoveTodoItem(long id)
    {
        throw new NotImplementedException();
    }
}