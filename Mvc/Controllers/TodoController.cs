using BL.Todos;
using BL.Users;
using Domain.Todos;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dto;
using Mvc.Models.Todo;

namespace Mvc.Controllers;

public class TodoController : Controller
{
    private readonly ITodoManager _todoManager;
    private readonly IUserManager _userManager;

    public TodoController(ITodoManager todoManager, IUserManager userManager)
    {
        _todoManager = todoManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var todos = _todoManager.GetAllTodos();
        var indexTodos = new List<TodoIndexViewModel>();
        foreach (var todo in todos)
        {
            var user = _userManager.GetUserById(todo.UserId);
            var Todoviewmodel = new TodoIndexViewModel()
            {
                Id = todo.Id,
                Description = todo.Description,
                StatusItem = todo.StatusItem,
                userId = todo.UserId ?? "N/A",
                Name = user.Name ?? "no Assigned user"
                
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

    [HttpGet]
    [Route("new")]
    public IActionResult New()
    {
        return View();
    }
    
    [HttpPost]
    [Route("new")]
    public IActionResult New( NewTodoModel newTodoModel )
    {
        _todoManager.AddTodoItem(newTodoModel.Description ,newTodoModel.StatusItem, newTodoModel.UserId);
        //TODO
        //get to detail of new todo or go to index page still undecided
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id, string description, StatusItem status, User user)
    {
        // var todo = _todoManager.EditTodoItem(id, description, status, user);
        return View();
    }
}