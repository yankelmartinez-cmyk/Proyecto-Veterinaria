using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Domain.Interfaces
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAllAsync();
        Task<Cita?> GetByIdAsync(int id);
        Task<Cita> CreateAsync(Cita cita);
        Task<Cita?> UpdateAsync(int id, Cita cita);
        Task<bool> DeleteAsync(int id);
    }
}