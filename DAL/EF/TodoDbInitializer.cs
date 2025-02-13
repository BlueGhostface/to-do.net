﻿using Domain.Todos;
using Domain.User;

namespace DAL.EF;

public class TodoDbInitializer
{
    private static bool _isInitialised;

    public static void Initialize(TodoDbContext context, bool dropCreateDatabase = false)
    {
        if (!_isInitialised)
        {
            if (dropCreateDatabase)
            {
                context.Database.EnsureDeleted();
                if (context.Database.EnsureCreated())
                {
                    seedUsers(context);
                    SeedDomain(context);
                    context.ChangeTracker.Clear();
                }

                _isInitialised = true;
            }
        }
    }

    private static void seedUsers(TodoDbContext context)
    {
        List<User> defaultUsers = new List<User>()
        {
            new() { Name = "alex", Email = "alex@email", Id = Guid.NewGuid() },
            new() { Name = "Sim", Email = "simmy@email", Id = Guid.NewGuid() }
        };

        context.Users.AddRange(defaultUsers);
        context.SaveChanges();
    }


    private static void SeedDomain(TodoDbContext context)
    {
        List<TodoItem> todoItems = new List<TodoItem>()
        {
            new TodoItem("Buy milk", StatusItem.BUSY),
            new TodoItem("Buy bread", StatusItem.OPEN),
            new TodoItem("Buy eggs", StatusItem.OPEN),
            new TodoItem("Buy cheese", StatusItem.DONE),
            new TodoItem("Buy butter", StatusItem.DONE),
        };

        context.TodoItems.AddRange(todoItems);
        context.SaveChanges();
        Console.WriteLine("Database initialized successfully with seed data linked to Alex.");
    }
}