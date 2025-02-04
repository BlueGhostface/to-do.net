using BL.Todos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dto;

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
    public IActionResult Get()
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
    
    [HttpPost]
    [AllowAnonymous]
    public IActionResult New([FromBody] NewTodoDto newTodoDto)
    {
        _todoManager.AddTodoItem(newTodoDto.Description, newTodoDto.StatusItem, newTodoDto.UserId);
        return Ok();
        
    }
    
    
}