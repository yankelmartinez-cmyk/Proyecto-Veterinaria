using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Veterinaria.Api.Infrastructure.Data.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly VeterinariaDbContext _context;

        public VeterinarioRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Veterinario>> GetAllAsync()
            => await _context.Veterinarios.ToListAsync();

        public async Task<Veterinario?> GetByIdAsync(int id)
            => await _context.Veterinarios.FindAsync(id);

        public async Task AddAsync(Veterinario veterinario)
        {
            _context.Veterinarios.Add(veterinario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Veterinario veterinario)
        {
            _context.Veterinarios.Update(veterinario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var v = await _context.Veterinarios.FindAsync(id);
            if (v != null)
            {
                _context.Veterinarios.Remove(v);
                await _context.SaveChangesAsync();
            }
        }
    }
}