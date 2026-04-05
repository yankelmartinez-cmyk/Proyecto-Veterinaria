using Veterinaria.Api.Application.DomainServices;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Domain.Interfaces;

namespace Veterinaria.Api.Application.AppServices
{
    public class ClienteAppService
    {
        private readonly IClienteRepository _repository;
        private readonly ClienteDomainService _domainService;

        public ClienteAppService(IClienteRepository repository, ClienteDomainService domainService)
        {
            _repository = repository;
            _domainService = domainService;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _domainService.Validar(cliente);
            return await _repository.CreateAsync(cliente);
        }

        public async Task<Cliente?> UpdateAsync(int id, Cliente cliente)
        {
            _domainService.Validar(cliente);
            return await _repository.UpdateAsync(id, cliente);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
