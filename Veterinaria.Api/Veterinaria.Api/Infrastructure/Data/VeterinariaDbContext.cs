using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Domain;
using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Infrastructure.Data
{
    public class VeterinariaDbContext : DbContext
    {
        public VeterinariaDbContext(DbContextOptions<VeterinariaDbContext> options)
            : base(options)
        {
        }

        // Una DbSet por cada tabla
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }

        // compañeros, agregen sus tablas aqui.
        
        // public DbSet<Veterinario> Veterinarios { get; set; }
        // public DbSet<Cliente> Clientes { get; set; }
        // public DbSet<TipoMascota> TiposMascota { get; set; }
    }
}