using DAL.EF;
using Domain.Todos;
using Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DAL.EF;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> Users { get; set; }
    
    

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
        TodoDbInitializer.Initialize(this, true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=todoDatabase.sqlite");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("todo");
        modelBuilder.Entity<TodoItem>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TodoItem>()
            .HasOne(t => t.User)
            .WithMany(u => u.TodoItems);
    }
}