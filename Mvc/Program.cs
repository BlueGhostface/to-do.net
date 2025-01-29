using DAL.EF;
using BL.Todos;
using BL.Users;
using DAL.EF.Todos;
using DAL.EF.Users;
using Domain.User;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<TodoDbContext>(options => 
    options.UseSqlite(connectionString));


builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<TodoDbContext>()
    .AddApiEndpoints();

//Managers
builder.Services.AddScoped<ITodoManager, TodoManager>();
builder.Services.AddScoped<IUserManager, UserManager>();

//Repositories
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

Env.Load();

builder.Configuration.AddEnvironmentVariables();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapIdentityApi<User>();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Todo}/{action=Index}",
        new { controller = "Todo", action = "Index" });



app.Run();