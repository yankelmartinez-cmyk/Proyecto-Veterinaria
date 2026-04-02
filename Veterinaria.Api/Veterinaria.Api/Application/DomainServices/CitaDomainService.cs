using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Application.DomainServices
{
    public class CitaDomainService
    {
        public void Validar(Cita cita)
        {
            if (cita.FechaHora == default)
                throw new ArgumentException("La fecha y hora de la cita es obligatoria.");

            if (cita.FechaHora < DateTime.Now)
                throw new ArgumentException("La fecha de la cita no puede ser en el pasado.");

            if (string.IsNullOrWhiteSpace(cita.Motivo))
                throw new ArgumentException("El motivo de la cita es obligatorio.");

            if (cita.IdMascota <= 0)
                throw new ArgumentException("Debe especificar una mascota válida.");

            if (cita.IdVeterinario <= 0)
                throw new ArgumentException("Debe especificar un veterinario válido.");
        }
    }
}