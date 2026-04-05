using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Domain.Interfaces
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<Mascota>> GetAllAsync();
        Task<Mascota?> GetByIdAsync(int id);
        Task AddAsync(Mascota mascota);
        Task UpdateAsync(Mascota mascota);
        Task DeleteAsync(int id);
    }
}
