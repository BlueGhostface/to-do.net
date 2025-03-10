﻿using BL.Todos;
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
                Title = todo.Title,
                Id = todo.Id,
                Description = todo.Description,
                StatusItem = todo.StatusItem,
                Name = user.Name ?? "no Assigned user"
                
            };
            indexTodos.Add(Todoviewmodel);
            Console.WriteLine("Todo Id: " + Todoviewmodel.Id + "Title :" + Todoviewmodel.Title + " Description: " + Todoviewmodel.Description + " Status: " + Todoviewmodel.StatusItem + " User: " + Todoviewmodel.Name);
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
            Title = todo.Title,
            Description = todo.Description,
            StatusItem = todo.StatusItem,
            UserId = todo.UserId,
            Name = user.Name ?? "no assigned user"
        };
        return View(detailTodo);
    }

    [HttpGet]
    [Route("new")]
    public IActionResult New()
    {
        var users = _userManager.GetAllUsers();
        ViewBag.Users = users;
        
        
        return View();
    }
    
    [HttpPost]
    // [Authorize]
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

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var todo = _todoManager.GetTodoById(id);
        
        var users = _userManager.GetAllUsers();
        ViewBag.Users = users;
        
        
        var editTodo = new EditTodoViewModel()
        {
            Id = todo.Id,
            Title = todo.Title,
            Description = todo.Description,
            StatusItem = todo.StatusItem
        };
        
        return View(editTodo);
    }
    
    [HttpPost]
    public IActionResult Edit(EditTodoViewModel editTodoViewModel)
    {
        if (editTodoViewModel.Id == Guid.Empty) // Or model.Id == null if it's a GUID
        {
            return BadRequest("Invalid ID");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var existingtodo = _todoManager.GetTodoById(editTodoViewModel.Id);
        var user = _userManager.GetUserById(editTodoViewModel.UserId);
        
        existingtodo.Title = editTodoViewModel.Title;
        existingtodo.Description = editTodoViewModel.Description;
        existingtodo.StatusItem = editTodoViewModel.StatusItem;
        existingtodo.UserId = user.Id;
        
        
        _todoManager.EditTodoItem(existingtodo);
        return RedirectToAction("Index");
    }
}