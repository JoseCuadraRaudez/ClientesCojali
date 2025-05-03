using Application;
using Application.Handlers;
using Infrastructure.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using System.Reflection;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // Ensamblado actual (Api)
    cfg.RegisterServicesFromAssembly(typeof(GetUsuariosHandler).Assembly); // Ensamblado Application
    cfg.RegisterServicesFromAssembly(typeof(CreateUsuarioHandler).Assembly); // Ensamblado Application (ya incluido si es el mismo que GetUsuariosHandler)
    cfg.RegisterServicesFromAssembly(typeof(UpdateUsuarioHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly);
});

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository, FileUsuarioRepository>();
builder.Services.AddScoped<IEmailService, FakeEmailService>();
builder.Services.AddScoped<IUsuarioRepository, MySqlUsuarioRepository>();

// Configurar MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string 'DefaultConnection' is not configured.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));




var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
