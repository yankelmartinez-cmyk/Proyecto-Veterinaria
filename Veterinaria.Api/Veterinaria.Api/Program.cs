using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data;
using Veterinaria.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// DbContext con SQL Server
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicios de Cita
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<CitaDomainService>();
builder.Services.AddScoped<CitaAppService>();

// Servicios de TipoMascota
builder.Services.AddScoped<ITipoMascotaRepository, TipoMascotaRepository>();
builder.Services.AddScoped<TipoMascotaDomainService>();
builder.Services.AddScoped<TipoMascotaAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
