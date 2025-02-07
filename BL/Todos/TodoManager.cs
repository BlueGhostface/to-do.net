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

    public IEnumerable<TodoItem> GetAllTodos()
    {
        return _todoRepository.ReadAllTodos();
    }

    public TodoItem GetTodoById(long id)
    {
        return _todoRepository.ReadTodoById(id);
    }

    public void AddTodoItem(string description, StatusItem status, string userId)
    {
        TodoItem newTodo = new TodoItem(description,status, userId);
        _todoRepository.CreateTodo(newTodo);
    }

    public void EditTodoItem(TodoItem todoItem)
    {
        _todoRepository.UpdateTodo(todoItem);
    }

    public void RemoveTodoItem(long id)
    {
        _todoRepository.DeleteTodoById(id);
    }
}