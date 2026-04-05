using Veterinaria.Api.Domain.Entities;
namespace Veterinaria.Api.Domain.Interfaces
{
    public interface IMascotaRepository
    {
        Task<IEnumerable<Mascota>> GetAllAsync();
        Task<Mascota?> GetByIdAsync(int id);
        Task<Mascota> CreateAsync(Mascota mascota);
        Task<Mascota?> UpdateAsync(int id, Mascota mascota);
        Task<bool> DeleteAsync(int id);
    }
}
