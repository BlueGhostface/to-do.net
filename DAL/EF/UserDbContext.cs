using Domain.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class UserDbContext : IdentityDbContext<User>
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.HasDefaultSchema("identity");
    }
}