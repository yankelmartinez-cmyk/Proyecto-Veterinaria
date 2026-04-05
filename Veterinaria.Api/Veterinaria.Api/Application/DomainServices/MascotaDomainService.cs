using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Application.DomainServices
{
    public class MascotaDomainService
    {
        public void Validar(Mascota mascota)
        {
            if (string.IsNullOrWhiteSpace(mascota.Nombre))
                throw new ArgumentException("El nombre de la mascota es obligatorio.");

            if (mascota.IdCliente <= 0)
                throw new ArgumentException("Debe especificar un cliente válido.");

            if (mascota.IdTipoMascota <= 0)
                throw new ArgumentException("Debe especificar un tipo de mascota válido.");
        }
    }
}