using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TaskManager.Core.Models;

namespace TaskManager.Core.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        // Seed data
        modelBuilder.Entity<Task>().HasData(
            new Task { Id = 1, Title = "Completar prueba técnica", Description = "Desarrollar aplicación fullstack .NET", IsCompleted = false, CreatedAt = DateTime.UtcNow },
            new Task { Id = 2, Title = "Revisar documentación", Description = "Leer la guía completa", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddDays(-1), CompletedAt = DateTime.UtcNow }
        );
    }
}