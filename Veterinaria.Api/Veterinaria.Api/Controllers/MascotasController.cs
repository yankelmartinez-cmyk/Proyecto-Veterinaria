using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Application.AppServices;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private readonly MascotaAppService _appService;

        public MascotasController(MascotaAppService appService)
        {
            _appService = appService;
        }

        // GET: api/mascotas
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mascotas = await _appService.GetAllAsync();
            return Ok(mascotas);
        }

        // GET: api/mascotas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mascota = await _appService.GetByIdAsync(id);
            if (mascota == null)
                return NotFound(new { mensaje = $"Mascota con ID {id} no encontrada." });
            return Ok(mascota);
        }

        // POST: api/mascotas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Mascota mascota)
        {
            try
            {
                var creada = await _appService.CreateAsync(mascota);
                return CreatedAtAction(nameof(GetById), new { id = creada.Id }, creada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT: api/mascotas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Mascota mascota)
        {
            try
            {
                var actualizada = await _appService.UpdateAsync(id, mascota);
                if (actualizada == null)
                    return NotFound(new { mensaje = $"Mascota con ID {id} no encontrada." });
                return Ok(actualizada);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/mascotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _appService.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = $"Mascota con ID {id} no encontrada." });
            return Ok(new { mensaje = $"Mascota con ID {id} inactivada correctamente." });
        }
    }
}