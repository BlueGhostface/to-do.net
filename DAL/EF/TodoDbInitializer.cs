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
                    Seed(context);
                    context.ChangeTracker.Clear();
                }

                _isInitialised = true;
            }
        }
    }


    private static void Seed(TodoDbContext context)
    {
        User stephan = new User("stephan", "stephan@email", "1");
        if (!context.Users.Any())
        {
            context.Users.Add(stephan);
        }

        if (!context.TodoItems.Any())
        {
            context.TodoItems.AddRange(new[]
            {
                new TodoItem("Buy milk", StatusItem.BUSY, stephan),
                new TodoItem("Buy bread", StatusItem.OPEN, stephan),
                new TodoItem("Buy eggs", StatusItem.OPEN, stephan),
                new TodoItem("Buy cheese", StatusItem.DONE, stephan),
                new TodoItem("Buy butter", StatusItem.DONE, stephan),
            });
        }

        // Save changes to the database
        context.SaveChanges();
        Console.WriteLine("Database initialized successfully with seed data linked to Alex.");
    }
}