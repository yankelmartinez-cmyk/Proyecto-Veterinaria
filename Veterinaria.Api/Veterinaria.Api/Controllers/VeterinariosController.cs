using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly VeterinarioAppService _appService;

        public VeterinariosController(VeterinarioAppService appService)
        {
            _appService = appService;
        }

        // GET: api/veterinarios
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var veterinarios = await _appService.GetAllAsync();
            return Ok(veterinarios);
        }

        // GET: api/veterinarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var veterinario = await _appService.GetByIdAsync(id);
            if (veterinario == null)
                return NotFound(new { mensaje = $"Veterinario con ID {id} no encontrado." });
            return Ok(veterinario);
        }

        // POST: api/veterinarios
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Veterinario veterinario)
        {
            try
            {
                var creado = await _appService.AddAsync(veterinario);
                return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT: api/veterinarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Veterinario veterinario)
        {
            try
            {
                var actualizado = await _appService.UpdateAsync(id, veterinario);
                if (actualizado == null)
                    return NotFound(new { mensaje = $"Veterinario con ID {id} no encontrado." });
                return Ok(actualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/veterinarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _appService.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = $"Veterinario con ID {id} no encontrado." });
            return Ok(new { mensaje = $"Veterinario con ID {id} inactivado correctamente." });
        }
    }
}