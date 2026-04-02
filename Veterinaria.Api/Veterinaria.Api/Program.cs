using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Infrastructure.Data;
using Veterinaria.Api.Infrastructure.Repositories;
using Veterinaria.Api.Application.AppServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Registro del Repositorio para la Inyección de Dependencias
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddScoped<MascotaRepository>();
builder.Services.AddScoped<MascotaAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
