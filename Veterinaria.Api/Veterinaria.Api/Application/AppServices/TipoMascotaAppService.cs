using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.AppServices
{
    public class TipoMascotaAppService
    {
        private readonly ITipoMascotaRepository _repository;
        private readonly TipoMascotaDomainService _domainService;

        public TipoMascotaAppService(ITipoMascotaRepository repository, TipoMascotaDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<IEnumerable<TipoMascota>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TipoMascota?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<TipoMascota> CreateAsync(TipoMascota tipoMascota)
        {
            _domainService.Validar(tipoMascota);
            return await _repository.CreateAsync(tipoMascota);
        }

        public async Task<TipoMascota?> UpdateAsync(int id, TipoMascota tipoMascota)
        {
            _domainService.Validar(tipoMascota);
            return await _repository.UpdateAsync(id, tipoMascota);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
