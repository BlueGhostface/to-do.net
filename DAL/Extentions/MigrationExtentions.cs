using DAL.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extentions;

public static class MigrationExtentions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        
        using TodoDbContext context = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
        context.Database.Migrate();
    }
    
}