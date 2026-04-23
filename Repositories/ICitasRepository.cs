using ClinicaAPI.Models;

namespace ClinicaAPI.Repositories
{
    public interface ICitasRepository
    {
        Task ProgramarCitaAsync(CitaProgramarRequest request);
        Task RegistrarDiagnosticoAsync(DiagnosticoRequest request);
        Task<IEnumerable<CitaDTO>> ObtenerCitasAsync();
    }
}