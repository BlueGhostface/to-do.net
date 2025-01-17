using BL.Todos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers.Api;

[ApiController]
[Route("api/Todos")]
public class TodosController : Controller
{
    
    private readonly ITodoManager _todoManager;

    public TodosController(ITodoManager todoManager)
    {
        _todoManager = todoManager;
    }
    
    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetTodos()
    {
        var todos = _todoManager.GetAllTodos();
        return Ok(todos);
    }
    
    [HttpGet]
    [AllowAnonymous]
    [Route("{id:int}")]
    public IActionResult GetTodoById(int id)
    {
        var todo = _todoManager.GetTodoById(id);
        return Ok(todo);
    }
    
    
}