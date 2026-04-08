using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.AppServices
{
    public class VeterinarioAppService
    {
        private readonly IVeterinarioRepository _repository;
        private readonly VeterinarioDomainService _domainService;

        public VeterinarioAppService(IVeterinarioRepository repository, VeterinarioDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Veterinario?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Veterinario> AddAsync(Veterinario veterinario)
        {
            _domainService.Validar(veterinario);
            return await _repository.AddAsync(veterinario);
        }

        public async Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario)
        {
            _domainService.Validar(veterinario);
            return await _repository.UpdateAsync(id, veterinario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}