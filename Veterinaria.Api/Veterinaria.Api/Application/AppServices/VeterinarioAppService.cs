using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.AppServices
{
    public class VeterinarioAppService
    {
        private readonly IVeterinarioRepository _repo;

        public VeterinarioAppService(IVeterinarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Veterinario>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<Veterinario?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<Veterinario> AddAsync(Veterinario veterinario)
            => await _repo.AddAsync(veterinario);

        public async Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario)
            => await _repo.UpdateAsync(id, veterinario);

        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}