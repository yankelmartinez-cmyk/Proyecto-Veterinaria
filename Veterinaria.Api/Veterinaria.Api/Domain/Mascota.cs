using System;

namespace Veterinaria.Api.Domain.Entities
{
    
    public class Mascota
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoMascota { get; set; }

        
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
