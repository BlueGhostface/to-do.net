﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Todos;

using User;

public class TodoItem
{
    [Key] public long Id { get; set; }
    [Required] public string Description { get; set; } = "";
    [Required] public StatusItem StatusItem { get; set; } = StatusItem.OPEN;
    [Required] public String UserId { get; set; }

    public TodoItem()
    {
    }


    public TodoItem(string description, StatusItem statusItem, string user) : this()
    {
        Description = description;
        StatusItem = statusItem;
        UserId = user;
    }
}