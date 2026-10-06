using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;
using ToDoApp.DataBaseRepo;
using ToDoApp.DataBaseRepo.Data;
using ToDoApp.Repositories;
using ToDoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// 1) Register services (before Build)
builder.Services.AddControllers();      // MVC controllers (+ authorization services)
builder.Services.AddOpenApi();          // OpenAPI document, used by Scalar

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TodoDb")));
builder.Services.AddScoped<ITodoRepository, EfTodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

// 2) Configure the middleware pipeline (after Build)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();                   // serves /openapi/v1.json
    app.MapScalarApiReference();        // serves /scalar/v1
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();