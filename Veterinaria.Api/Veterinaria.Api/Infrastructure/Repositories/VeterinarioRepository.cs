using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Api.Infrastructure.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly VeterinariaDbContext _context;

        public VeterinarioRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return await _context.Veterinarios
                .Where(v => v.Activo)
                .ToListAsync();
        }

        public async Task<Veterinario?> GetByIdAsync(int id)
        {
            return await _context.Veterinarios
                .FirstOrDefaultAsync(v => v.Id == id && v.Activo);
        }

        public async Task<Veterinario> AddAsync(Veterinario veterinario)
        {
            veterinario.FechaCreacion = DateTime.Now;
            veterinario.Activo = true;
            _context.Veterinarios.Add(veterinario);
            await _context.SaveChangesAsync();
            return veterinario;
        }

        public async Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario)
        {
            var existing = await _context.Veterinarios.FindAsync(id);
            if (existing == null || !existing.Activo) return null;
            existing.Nombre = veterinario.Nombre;
            existing.Apellido = veterinario.Apellido;
            existing.Especialidad = veterinario.Especialidad;
            existing.Telefono = veterinario.Telefono;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var veterinario = await _context.Veterinarios.FindAsync(id);
            if (veterinario == null || !veterinario.Activo) return false;
            veterinario.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}