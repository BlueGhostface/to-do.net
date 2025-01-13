﻿using DAL.EF;
using Domain.Todos;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class TodoDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }
    public DbSet<User> Users { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
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
        modelBuilder.Entity<TodoItem>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<TodoItem>()
            .HasOne(t => t.User)
            .WithMany(u => u.TodoItems);
    }
}