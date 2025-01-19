using BL.Todos;
using Domain.Todos;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

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
        return View(todos);
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