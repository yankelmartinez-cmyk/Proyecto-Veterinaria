using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.AppServices
{
    public class MascotaAppService
    {
        private readonly IMascotaRepository _repository;
        private readonly MascotaDomainService _domainService;

        public MascotaAppService(IMascotaRepository repository, MascotaDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Mascota?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Mascota> CreateAsync(Mascota mascota)
        {
            _domainService.Validar(mascota);
            return await _repository.CreateAsync(mascota);
        }

        public async Task<Mascota?> UpdateAsync(int id, Mascota mascota)
        {
            _domainService.Validar(mascota);
            return await _repository.UpdateAsync(id, mascota);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}