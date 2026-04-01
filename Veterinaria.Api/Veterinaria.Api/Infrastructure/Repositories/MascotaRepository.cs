
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Api.Infrastructure.Repositories
{
    
    public class MascotaRepository
    {
        private readonly VeterinariaDbContext _context;

        public MascotaRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        // Método para listar mascotas activas
        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _context.Mascotas.Where(m => m.Activo).ToListAsync();
        }

        // Método para registrar una nueva mascota
        public async Task AddAsync(Mascota mascota)
        {
            await _context.Mascotas.AddAsync(mascota);
            await _context.SaveChangesAsync();
        }
    }
}