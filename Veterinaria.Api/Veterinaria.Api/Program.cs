using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteDomainService>();
builder.Services.AddScoped<ClienteAppService>();

// Registrar DbContext
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar repositorios y servicios de Citas
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<CitaDomainService>();
builder.Services.AddScoped<CitaAppService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();