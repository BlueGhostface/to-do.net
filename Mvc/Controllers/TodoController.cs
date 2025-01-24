using BL.Todos;
using Domain.Todos;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Todo;

namespace Mvc.Controllers;

public class TodoController : Controller
{
    private readonly ITodoManager _todoManager;

    public TodoController(ITodoManager todoManager)
    {
        _todoManager = todoManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var todos = _todoManager.GetAllTodos();
        var indexTodos = new List<TodoIndexViewModel>();
        foreach (var todo in todos)
        {
            var Todoviewmodel = new TodoIndexViewModel()
            {
                Id = todo.Id,
                Description = todo.Description,
                StatusItem = todo.StatusItem,
                Name = todo.User.Name ?? "no Assigned user"
            };
            indexTodos.Add(Todoviewmodel);
            Console.WriteLine("Todo Id: " + Todoviewmodel.Id + " Description: " + Todoviewmodel.Description + " Status: " + Todoviewmodel.StatusItem + " User: " + Todoviewmodel.Name);
        }

        return View(indexTodos);
    }

    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Detail(int id)
    {
        var todo = _todoManager.GetTodoById(id);
        return View(todo);
    }

    [HttpPost]
    [Route("new")]
    public IActionResult New(string description, StatusItem status, User user)
    {
        var todo = _todoManager.AddTodoItem(description, status, user);
        return View(todo);
    }

    public IActionResult Edit(int id, string description, StatusItem status, User user)
    {
        // var todo = _todoManager.EditTodoItem(id, description, status, user);
        return View();
    }
}