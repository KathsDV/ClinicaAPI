using ClinicaAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClinicaAPI.Repositories
{
    public class CitasRepository : ICitasRepository
    {
        private readonly string _connectionString;

        public CitasRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public async Task ProgramarCitaAsync(CitaProgramarRequest request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_ProgramarCita", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PacienteId", request.PacienteId);
                    command.Parameters.AddWithValue("@DoctorId", request.DoctorId);
                    command.Parameters.AddWithValue("@FechaHora", request.FechaHora);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task RegistrarDiagnosticoAsync(DiagnosticoRequest request)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_RegistrarDiagnostico", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CitaId", request.CitaId);
                    command.Parameters.AddWithValue("@Diagnostico", request.Diagnostico);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<CitaDTO>> ObtenerCitasAsync()
        {
            var citas = new List<CitaDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_ObtenerCitas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            citas.Add(new CitaDTO
                            {
                                Id = reader.GetInt32(0),
                                Paciente = reader.GetString(1),
                                Doctor = reader.GetString(2),
                                FechaHora = reader.GetDateTime(3),
                                Diagnostico = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }
            }
            return citas;
        }
    }
}