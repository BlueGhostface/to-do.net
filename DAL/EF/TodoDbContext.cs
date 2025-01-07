using Domain.Todos;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class TodoDbContext : DbContext
{
    
    DbSet<TodoItem> TodoItems { get; set; }
    
    public TodoDbContext(DbContextOptions options) : base(options)
    {
        TodoDbInitializer.Initialize(this, true);
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<TodoItem>()
            .HasOne(todoItem => todoItem.User)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<User>()
            .HasMany(user  => user.TodoItems )
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}