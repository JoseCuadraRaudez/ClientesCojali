using Application;
using Application.Handlers;
using Infrastructure.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using MediatR;
using System.Reflection;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
