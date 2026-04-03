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

        public async Task<List<Veterinario>> GetAllAsync()
            => await _repo.GetAllAsync();

        public async Task<Veterinario?> GetByIdAsync(int id)
            => await _repo.GetByIdAsync(id);

        public async Task AddAsync(Veterinario veterinario)
            => await _repo.AddAsync(veterinario);

        public async Task UpdateAsync(Veterinario veterinario)
            => await _repo.UpdateAsync(veterinario);

        public async Task DeleteAsync(int id)
            => await _repo.DeleteAsync(id);
    }
}