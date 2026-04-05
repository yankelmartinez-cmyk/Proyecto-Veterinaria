using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Domain.Interfaces
{
    public interface ITipoMascotaRepository
    {
        Task<IEnumerable<TipoMascota>> GetAllAsync();
        Task<TipoMascota?> GetByIdAsync(int id);
        Task<TipoMascota> CreateAsync(TipoMascota tipoMascota);
        Task<TipoMascota?> UpdateAsync(int id, TipoMascota tipoMascota);
        Task<bool> DeleteAsync(int id);
    }
}
