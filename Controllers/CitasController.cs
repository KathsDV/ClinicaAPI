using ClinicaAPI.Models;
using ClinicaAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitasRepository _citasRepository;

        public CitasController(ICitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var citas = await _citasRepository.ObtenerCitasAsync();
                return Ok(citas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPost("Programar")]
        public async Task<IActionResult> ProgramarCita([FromBody] CitaProgramarRequest request)
        {
            try
            {
                await _citasRepository.ProgramarCitaAsync(request);
                return Ok("Cita programada exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut("Diagnostico")]
        public async Task<IActionResult> RegistrarDiagnostico([FromBody] DiagnosticoRequest request)
        {
            try
            {
                await _citasRepository.RegistrarDiagnosticoAsync(request);
                return Ok("Diagnóstico registrado exitosamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}