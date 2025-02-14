using Domain.Todos;
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
            
            new() { Name = "alex", Email = "alex@email", },
            new() { Name = "Sim", Email = "simmy@email", },
        };

        context.Users.AddRange(defaultUsers);
        context.SaveChanges();
        context.ChangeTracker.Clear();
    }


    private static void SeedDomain(TodoDbContext context)
    {
        var user1 = context.Users.SingleOrDefault(user => user.Name == "alex");
        var user2 = context.Users.SingleOrDefault(user => user.Name == "Sim");
        
        List<TodoItem> todoItems = new List<TodoItem>()
        {
            new TodoItem("Buy milk","going to the store to buy milk", StatusItem.BUSY, user1),
            new TodoItem("Buy bread", "going to the store to buy bread", StatusItem.OPEN , user1),
            new TodoItem("Buy eggs", "go to the market to buy eggs", StatusItem.OPEN , user1),
            new TodoItem("clean the house","take a broom and sweep up all the dust from the house", StatusItem.DONE, user2),
            new TodoItem("fill up the car","go to the gas station to fill up the gas tank", StatusItem.DONE, user2),
        };

        context.TodoItems.AddRange(todoItems);
        context.SaveChanges();
        Console.WriteLine("Database initialized successfully with seed data linked to Alex.");
    }
    
    
}