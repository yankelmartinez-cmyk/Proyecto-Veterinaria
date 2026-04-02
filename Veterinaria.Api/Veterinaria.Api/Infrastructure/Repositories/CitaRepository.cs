using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;
using Veterinaria.Api.Infrastructure.Data;

namespace Veterinaria.Api.Infrastructure.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly VeterinariaDbContext _context;

        public CitaRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET - Listar todas las citas activas
        public async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _context.Citas
                .Where(c => c.Activo)
                .ToListAsync();
        }

        // GET por ID - Obtener una cita por su id
        public async Task<Cita?> GetByIdAsync(int id)
        {
            return await _context.Citas
                .FirstOrDefaultAsync(c => c.Id == id && c.Activo);
        }

        // POST - Agregar una nueva cita
        public async Task<Cita> CreateAsync(Cita cita)
        {
            cita.FechaCreacion = DateTime.Now;
            cita.Activo = true;
            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        // PUT - Actualizar una cita existente
        public async Task<Cita?> UpdateAsync(int id, Cita cita)
        {
            var existing = await _context.Citas.FindAsync(id);
            if (existing == null || !existing.Activo) return null;

            existing.FechaHora = cita.FechaHora;
            existing.Motivo = cita.Motivo;
            existing.Diagnostico = cita.Diagnostico;
            existing.IdMascota = cita.IdMascota;
            existing.IdVeterinario = cita.IdVeterinario;

            await _context.SaveChangesAsync();
            return existing;
        }

        // DELETE - Inactivar una cita
        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null || !cita.Activo) return false;

            cita.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}