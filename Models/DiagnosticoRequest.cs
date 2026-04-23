namespace ClinicaAPI.Models
{
    public class DiagnosticoRequest
    {
        public int CitaId { get; set; }
        public string Diagnostico { get; set; } = string.Empty;
    }
}
