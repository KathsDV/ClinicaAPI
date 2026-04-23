namespace ClinicaAPI.Models
{
    public class CitaProgramarRequest
    {
        public int PacienteId { get; set; }
        public int DoctorId { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
