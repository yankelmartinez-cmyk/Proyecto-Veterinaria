using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Domain.Interfaces
{
    public interface IVeterinarioRepository
    {
        Task<IEnumerable<Veterinario>> GetAllAsync();
        Task<Veterinario?> GetByIdAsync(int id);
        Task<Veterinario> AddAsync(Veterinario veterinario);
        Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario);
        Task<bool> DeleteAsync(int id);
    }
}
