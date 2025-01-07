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
                    //seed data
                    context.ChangeTracker.Clear();
                }
                _isInitialised = true;
            }
        }
    }
}