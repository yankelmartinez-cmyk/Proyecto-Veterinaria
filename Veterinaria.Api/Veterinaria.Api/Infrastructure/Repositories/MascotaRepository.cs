using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Api.Infrastructure.Repositories
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly VeterinariaDbContext _context;

        public MascotaRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET - Listar todas las mascotas activas
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

        // POST - Agregar una nueva mascota
        public async Task AddAsync(Mascota mascota)
        {
            await _context.Mascotas.AddAsync(mascota);
            await _context.SaveChangesAsync();
        }

        // PUT - Actualizar una mascota existente
        public async Task UpdateAsync(Mascota mascota)
        {
            _context.Mascotas.Update(mascota);
            await _context.SaveChangesAsync();
        }

        // DELETE - Inactivar una mascota
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