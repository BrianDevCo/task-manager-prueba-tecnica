using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Data;
using TaskManager.Core.Mappings;
using TaskManager.Core.Repositories;
using TaskManager.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Task Manager API",
        Version = "v1",
        Description = "API REST para gestión de tareas personales"
    });
});

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=(localdb)\\mssqllocaldb;Database=TaskManagerDB;Trusted_Connection=true;TrustServerCertificate=true";

builder.Services.AddDbContext<TaskDbContext>(options =>
    options.UseSqlServer(connectionString));

// Repository Pattern
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Service Layer
builder.Services.AddScoped<ITaskService, TaskService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(TaskMappingProfile));

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
    {
        policy.WithOrigins("https://localhost:7002", "http://localhost:5002")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazorApp");

app.UseAuthorization();

app.MapControllers();

// Database Migration and Seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TaskDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error al migrar la base de datos");
    }
}

app.Run();
```

### 3.10 Configurar appsettings.json (TaskManager.API)

1. * *Abre `appsettings.json` en `TaskManager.API`**
2. **Reemplaza el contenido con:**

```json
{
  "Logging": {
    "LogLevel": {
        "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
},
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TaskManagerDB;Trusted_Connection=true;TrustServerCertificate=true"
  }
}