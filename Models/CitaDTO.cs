namespace ClinicaAPI.Models
{
    public class CitaDTO
    {
        public int Id { get; set; }
        public string Paciente { get; set; } = string.Empty;
        public string Doctor { get; set; } = string.Empty;
        public DateTime FechaHora { get; set; }
        public string? Diagnostico { get; set; }
    }
}
