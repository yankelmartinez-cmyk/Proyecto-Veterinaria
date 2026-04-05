using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data;

namespace Veterinaria.Api.Infrastructure.Repositories
{
    public class TipoMascotaRepository : ITipoMascotaRepository
    {
        private readonly VeterinariaDbContext _context;

        public TipoMascotaRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoMascota>> GetAllAsync()
        {
            return await _context.TiposMascota
                .Where(t => t.Activo)
                .ToListAsync();
        }

        public async Task<TipoMascota?> GetByIdAsync(int id)
        {
            return await _context.TiposMascota
                .FirstOrDefaultAsync(t => t.Id == id && t.Activo);
        }

        public async Task<TipoMascota> CreateAsync(TipoMascota tipoMascota)
        {
            tipoMascota.FechaCreacion = DateTime.Now;
            tipoMascota.Activo = true;

            await _context.TiposMascota.AddAsync(tipoMascota);
            await _context.SaveChangesAsync();
            return tipoMascota;
        }

        public async Task<TipoMascota?> UpdateAsync(int id, TipoMascota tipoMascota)
        {
            var existente = await _context.TiposMascota.FindAsync(id);
            if (existente == null || !existente.Activo) return null;

            existente.Nombre = tipoMascota.Nombre;
            existente.Descripcion = tipoMascota.Descripcion;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tipoMascota = await _context.TiposMascota.FindAsync(id);
            if (tipoMascota == null || !tipoMascota.Activo) return false;

            tipoMascota.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
