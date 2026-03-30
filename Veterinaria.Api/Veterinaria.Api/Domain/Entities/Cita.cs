namespace Veterinaria.Api.Domain.Entities
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; } = string.Empty;
        public string? Diagnostico { get; set; }
        public int IdMascota { get; set; }
        public int IdVeterinario { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        // Relaciones de navegación
       // public Mascota? Mascota { get; set; }
       // public Veterinario? Veterinario { get; set; }
    }
}