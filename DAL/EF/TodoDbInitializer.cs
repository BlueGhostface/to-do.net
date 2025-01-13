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
                    Seed(context);
                    context.ChangeTracker.Clear();
                }

                _isInitialised = true;
            }
        }
    }


    private static void Seed(TodoDbContext context)
    {
        User alex = new User("alex", "alex@email", 1);
        if (!context.Users.Any())
        {
            context.Users.Add(alex);
        }

        if (!context.TodoItems.Any())
        {
            context.TodoItems.AddRange(new[]
            {
                new TodoItem("Buy milk", StatusItem.BUSY, alex),
                new TodoItem("Buy bread", StatusItem.OPEN, alex),
                new TodoItem("Buy eggs", StatusItem.OPEN, alex),
                new TodoItem("Buy cheese", StatusItem.DONE, alex),
                new TodoItem("Buy butter", StatusItem.DONE, alex),
            });
        }

        // Save changes to the database
        context.SaveChanges();
        Console.WriteLine("Database initialized successfully with seed data linked to Alex.");
    }
}