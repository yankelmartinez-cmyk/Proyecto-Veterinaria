using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Application.DomainServices
{
    public class TipoMascotaDomainService
    {
        public void Validar(TipoMascota tipoMascota)
        {
            if (string.IsNullOrWhiteSpace(tipoMascota.Nombre))
                throw new ArgumentException("El nombre del tipo de mascota es obligatorio.");
        }
    }
}
