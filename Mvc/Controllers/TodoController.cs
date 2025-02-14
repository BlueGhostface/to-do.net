using BL.Todos;
using BL.Users;
using Domain.Todos;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
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
                title = todo.Title,
                Id = todo.Id,
                Description = todo.Description,
                StatusItem = todo.StatusItem,
                Name = user.Name ?? "no Assigned user"
                
            };
            indexTodos.Add(Todoviewmodel);
            Console.WriteLine("Todo Id: " + Todoviewmodel.Id + "Title :" + Todoviewmodel.title + " Description: " + Todoviewmodel.Description + " Status: " + Todoviewmodel.StatusItem + " User: " + Todoviewmodel.Name);
        }

        return View(indexTodos);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Detail(Guid id)
    {
        var todo = _todoManager.GetTodoById(id);
        Console.WriteLine("finding todo by id: " + id);
        var user = _userManager.GetUserById(todo.UserId);
        var detailTodo = new TodoIndexViewModel()
        {
            Id = todo.Id,
            title = todo.Title,
            Description = todo.Description,
            StatusItem = todo.StatusItem,
            userId = todo.UserId,
            Name = user.Name ?? "no assigned user"
        };
        return View(detailTodo);
    }

    [HttpGet]
    [Route("new")]
    public IActionResult New()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize]
    [Route("new")]
    public IActionResult New( NewTodoDto newTodoDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = _userManager.GetUserById(newTodoDto.UserId);
        
        _todoManager.AddTodoItem(newTodoDto.Title, newTodoDto.Description ,newTodoDto.StatusItem, user);
        return RedirectToAction("Index");
        // var newTodoId = _todoManager.AddTodoItem(newTodoDto.Description, newTodoDto.StatusItem, newTodoDto.UserId);
        // return RedirectToAction("Detail", new { id = newTodoId });
    }

    public IActionResult Edit(int id, string description, StatusItem status, User user)
    {
        // var todo = _todoManager.EditTodoItem(id, description, status, user);
        return View();
    }
}