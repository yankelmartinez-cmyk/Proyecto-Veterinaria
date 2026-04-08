using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.DomainServices
{
    public class MascotaDomainService
    {
        private readonly IMascotaRepository _repository;

        public MascotaDomainService(IMascotaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Mascota?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Mascota mascota)
        {
            await _repository.AddAsync(mascota);
        }

        public async Task UpdateAsync(Mascota mascota)
        {
            await _repository.UpdateAsync(mascota);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}