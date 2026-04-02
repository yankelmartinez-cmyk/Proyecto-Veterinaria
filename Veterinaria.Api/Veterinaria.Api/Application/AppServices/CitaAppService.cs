using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.AppServices
{
    public class CitaAppService
    {
        private readonly ICitaRepository _repository;
        private readonly CitaDomainService _domainService;

        public CitaAppService(ICitaRepository repository, CitaDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cita?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Cita> CreateAsync(Cita cita)
        {
            _domainService.Validar(cita);
            return await _repository.CreateAsync(cita);
        }

        public async Task<Cita?> UpdateAsync(int id, Cita cita)
        {
            _domainService.Validar(cita);
            return await _repository.UpdateAsync(id, cita);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}