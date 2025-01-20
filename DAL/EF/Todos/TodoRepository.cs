using Domain.Todos;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Todos;

public class TodoRepository : ITodoRepository
{
    
    private readonly TodoDbContext _todoDbContext;
    
    public TodoRepository(TodoDbContext todoDbContext)
    {
        _todoDbContext = todoDbContext;
    }
    
    public IEnumerable<TodoItem> ReadAllTodos()
    {
        return _todoDbContext.TodoItems.Include(todo => todo.User);
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