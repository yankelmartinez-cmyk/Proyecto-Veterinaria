using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Infrastructure.Repositories;

namespace Veterinaria.Api.Application.AppServices
{
    public class MascotaAppService
    {
        private readonly MascotaRepository _repository;

        public MascotaAppService(MascotaRepository repository)
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