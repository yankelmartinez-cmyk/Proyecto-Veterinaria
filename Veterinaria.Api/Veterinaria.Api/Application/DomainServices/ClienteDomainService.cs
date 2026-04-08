using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Application.DomainServices
{
    public class ClienteDomainService
    {
        public void Validar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");

            if (!string.IsNullOrWhiteSpace(cliente.Correo) && !cliente.Correo.Contains("@"))
                throw new ArgumentException("El correo electrónico no tiene un formato válido.");

            if (!string.IsNullOrWhiteSpace(cliente.Telefono) && cliente.Telefono.Length > 15)
                throw new ArgumentException("El teléfono no puede tener más de 15 caracteres.");
        }
    }
}
