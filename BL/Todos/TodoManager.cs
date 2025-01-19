using DAL.EF.Todos;
using Domain.Todos;
using Domain.User;

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

    public TodoItem AddTodoItem(string description,StatusItem status, User user)
    {
        TodoItem newTodo = new TodoItem( description,status, user);
        return _todoRepository.CreateTodo(newTodo);
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