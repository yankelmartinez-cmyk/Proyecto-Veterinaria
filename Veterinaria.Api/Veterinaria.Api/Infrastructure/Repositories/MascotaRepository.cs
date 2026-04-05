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

        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _context.Mascotas
                .Where(m => m.Activo)
                .ToListAsync();
        }

        public async Task<Mascota?> GetByIdAsync(int id)
        {
            return await _context.Mascotas
                .FirstOrDefaultAsync(m => m.Id == id && m.Activo);
        }

        public async Task<Mascota> CreateAsync(Mascota mascota)
        {
            mascota.FechaCreacion = DateTime.Now;
            mascota.Activo = true;
            await _context.Mascotas.AddAsync(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task<Mascota?> UpdateAsync(int id, Mascota mascota)
        {
            var existing = await _context.Mascotas.FindAsync(id);
            if (existing == null || !existing.Activo) return null;

            existing.Nombre = mascota.Nombre;
            existing.FechaNacimiento = mascota.FechaNacimiento;
            existing.IdCliente = mascota.IdCliente;
            existing.IdTipoMascota = mascota.IdTipoMascota;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null || !mascota.Activo) return false;

            mascota.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}