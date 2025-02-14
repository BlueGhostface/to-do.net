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
        return _todoDbContext.TodoItems.ToList();
    }

    public TodoItem ReadTodoById(Guid id)
    {
        return _todoDbContext.TodoItems
            .FirstOrDefault(todo => todo.Id == id) ?? throw new InvalidOperationException();
    }

    public void CreateTodo(TodoItem todoItem)
    {
        _todoDbContext.TodoItems.Add(todoItem);
        _todoDbContext.SaveChanges();
    }

    public void UpdateTodo(TodoItem todoItem)
    {
        _todoDbContext.TodoItems.Update(todoItem);
        _todoDbContext.SaveChanges();
    }

    public void DeleteTodo(TodoItem todoItem)
    {
        _todoDbContext.TodoItems.Remove(todoItem);
    }

    public void DeleteTodoById(Guid id)
    {
        var todoItem = ReadTodoById(id);
        _todoDbContext.TodoItems.Remove(todoItem);
        _todoDbContext.SaveChanges();
    }
}