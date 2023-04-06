using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ToDoAPI.Data;
using ToDoAPI.Services.ToDoServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/todos", async (IToDoService service) =>
{
    return await service.GetAllTodos();
});

app.MapGet("/todos/{id}", async (IToDoService service, int id) =>
{
    return await service.GetSingleToDo(id);
});

app.MapPost("/todos", async (IToDoService service, ToDo todo) =>
{
    return await service.AddToDo(todo);
});

app.MapPatch("/todos/{id}", async (IToDoService service, int id, [FromBody] ToDo update) =>
{
    return await service.UpdateSomeToDo(id, update);
});

app.MapPut("/todos/{id}", async (IToDoService service, int id, ToDo newToDo) =>
{
    return await service.UpdateAll(id, newToDo);
});

app.MapDelete("/todos/{id}", async (IToDoService service, int id) =>
{
   return await service.DeleteToDo(id);
});

app.Run();

public class ToDo
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; } 
    public DateTime AddedIn { get; set; }
}

