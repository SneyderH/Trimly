using Microsoft.AspNetCore.Mvc;
using Trimly.Application.Contracts;
using Trimly.Application.DTOs;

namespace Trimly.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitaService _citaService;

        public CitasController(ICitaService citaService)
        { 
            _citaService = citaService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearCita([FromBody] CrearCitaDto dto)
        {
            try
            {
                var result = await _citaService.CrearCitaAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
