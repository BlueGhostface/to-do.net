﻿using DAL.EF.Todos;
using Domain.Todos;
using Domain.User;

namespace BL.Todos;

public class TodoManager : ITodoManager
{
    
    private readonly ITodoRepository _todoRepository;

    public TodoManager(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public IEnumerable<TodoItem> GetAllTodos()
    {
        return _todoRepository.ReadAllTodos();
    }

    public TodoItem GetTodoById(Guid id)
    {
        return _todoRepository.ReadTodoById(id);
    }

    public void AddTodoItem(string title, string description, StatusItem status, User user)
    {
        TodoItem newTodo = new TodoItem(title,description,status,user);
        _todoRepository.CreateTodo(newTodo);
    }

    public void AddTodoItem(TodoItem todoItem)
    {
        _todoRepository.CreateTodo(todoItem);
    }

    public void EditTodoItem(TodoItem todoItem)
    {
        _todoRepository.UpdateTodo(todoItem);
    }

    public void RemoveTodoItem(Guid id)
    {
        _todoRepository.DeleteTodoById(id);
    }
}