using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Application.DomainServices
{
    public class VeterinarioDomainService
    {
        public void Validar(Veterinario veterinario)
        {
            if (string.IsNullOrWhiteSpace(veterinario.Nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(veterinario.Apellido))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(veterinario.Especialidad))
                throw new ArgumentException("La especialidad es obligatoria.");
        }
    }
}