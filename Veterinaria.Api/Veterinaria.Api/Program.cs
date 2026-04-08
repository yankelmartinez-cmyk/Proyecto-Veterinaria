using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data;
using Veterinaria.Api.Infrastructure.Data.Repositories;
using Veterinaria.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Registrar DbContext
builder.Services.AddDbContext<VeterinariaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Citas - Yankel
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<CitaDomainService>();
builder.Services.AddScoped<CitaAppService>();

// Clientes - Cesia
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteDomainService>();
builder.Services.AddScoped<ClienteAppService>();

// Mascotas - Aslhey
builder.Services.AddScoped<IMascotaRepository, MascotaRepository>();
builder.Services.AddScoped<MascotaDomainService>();
builder.Services.AddScoped<MascotaAppService>();

// Veterinarios - Neyzer
builder.Services.AddScoped<IVeterinarioRepository, VeterinarioRepository>();
builder.Services.AddScoped<VeterinarioDomainService>();
builder.Services.AddScoped<VeterinarioAppService>();

// TiposMascota - Rony
builder.Services.AddScoped<ITipoMascotaRepository, TipoMascotaRepository>();
builder.Services.AddScoped<TipoMascotaDomainService>();
builder.Services.AddScoped<TipoMascotaAppService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();