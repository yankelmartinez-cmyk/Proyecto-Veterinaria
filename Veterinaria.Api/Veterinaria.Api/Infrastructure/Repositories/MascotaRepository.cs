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

        
        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _context.Mascotas
                .Where(m => m.Activo)
                .ToListAsync();
        }

        // GET por ID - Obtener una mascota por su id
        public async Task<Mascota?> GetByIdAsync(int id)
        {
            return await _context.Mascotas.FindAsync(id);
        }

        
        public async Task AddAsync(Mascota mascota)
        {
            await _context.Mascotas.AddAsync(mascota);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAsync(Mascota mascota)
        {
            _context.Mascotas.Update(mascota);
            await _context.SaveChangesAsync();
        }

        
        public async Task DeleteAsync(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                mascota.Activo = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}