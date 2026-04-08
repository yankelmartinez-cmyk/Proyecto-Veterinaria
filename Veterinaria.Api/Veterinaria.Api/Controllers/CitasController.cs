using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly CitaAppService _appService;

        public CitasController(CitaAppService appService)
        {
            _appService = appService;
        }

        // GET: api/citas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var citas = await _appService.GetAllAsync();
            return Ok(citas);
        }

        // GET: api/citas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cita = await _appService.GetByIdAsync(id);
            if (cita == null)
                return NotFound(new { mensaje = $"Cita con ID {id} no encontrada." });
            return Ok(cita);
        }

        // POST: api/citas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cita cita)
        {
            try
            {
                var creada = await _appService.CreateAsync(cita);
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT: api/citas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cita cita)
        {
            try
            {
                var actualizada = await _appService.UpdateAsync(id, cita);
                if (actualizada == null)
                    return NotFound(new { mensaje = $"Cita con ID {id} no encontrada." });
                return Ok(actualizada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/citas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _appService.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = $"Cita con ID {id} no encontrada." });
            return Ok(new { mensaje = $"Cita con ID {id} inactivada correctamente." });
        }
    }
}