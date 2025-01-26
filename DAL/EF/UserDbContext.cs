using Domain.Todos;
using Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DAL.EF;

public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>()
            .HasKey(u => u.Id);

        // builder.Entity<User>()
        //     .HasMany(user => user.TodoItems);
        //     

        builder.Entity<User>().HasData(seedUsers);


        builder.HasDefaultSchema("identity");
    }

    private static readonly User[] seedUsers =
    {
        new() { Name = "alex", Email = "alex@email", Id = "1" },
        new() { Name = "Sim", Email = "simmy@email", Id = "2" }
    };
}