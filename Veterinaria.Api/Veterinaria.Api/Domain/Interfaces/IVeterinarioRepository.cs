using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Domain.Interfaces
{
    public interface IVeterinarioRepository
    {
        Task<List<Veterinario>> GetAllAsync();
        Task<Veterinario?> GetByIdAsync(int id);
        Task AddAsync(Veterinario veterinario);
        Task UpdateAsync(Veterinario veterinario);
        Task DeleteAsync(int id);
    }
}
