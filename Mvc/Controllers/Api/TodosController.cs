﻿using BL.Todos;
using BL.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models.Dto;

namespace Mvc.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    
    private readonly ITodoManager _todoManager;
    private readonly IUserManager _userManager;

    public TodosController(ITodoManager todoManager, IUserManager userManager)
    {
        _todoManager = todoManager;
        _userManager = userManager;
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
    [Route("{id:guid}")]
    public IActionResult GetTodoById(Guid id)
    {
        var todo = _todoManager.GetTodoById(id);
        return Ok(todo);
    }
    
    [HttpPost]
    [AllowAnonymous]
    public IActionResult New([FromBody] NewTodoDto newTodoDto)
    {
        var user = _userManager.GetUserById(newTodoDto.UserId);
        _todoManager.AddTodoItem(newTodoDto.Title, newTodoDto.Description, newTodoDto.StatusItem, user);
        return Ok();
        
    }
    
    
}