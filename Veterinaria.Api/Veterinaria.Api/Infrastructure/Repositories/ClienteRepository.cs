using Microsoft.EntityFrameworkCore;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VeterinariaDbContext _context;

        public ClienteRepository(VeterinariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes
                .Where(c => c.Activo)
                .ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes
                .FirstOrDefaultAsync(c => c.Id == id && c.Activo);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            cliente.FechaCreacion = DateTime.Now;
            cliente.Activo = true;
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente?> UpdateAsync(int id, Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(id);
            if (existing == null || !existing.Activo) return null;

            existing.Nombre = cliente.Nombre;
            existing.Apellido = cliente.Apellido;
            existing.Telefono = cliente.Telefono;
            existing.Correo = cliente.Correo;
            existing.Direccion = cliente.Direccion;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null || !cliente.Activo) return false;

            cliente.Activo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
