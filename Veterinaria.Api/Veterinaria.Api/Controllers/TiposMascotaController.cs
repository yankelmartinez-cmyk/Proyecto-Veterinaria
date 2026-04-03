using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiposMascotaController : ControllerBase
    {
        private readonly TipoMascotaAppService _appService;

        public TiposMascotaController(TipoMascotaAppService appService)
        {
            _appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tipos = await _appService.GetAllAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipo = await _appService.GetByIdAsync(id);

            if (tipo == null)
                return NotFound(new { mensaje = $"TipoMascota con ID {id} no encontrado." });

            return Ok(tipo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoMascota tipoMascota)
        {
            try
            {
                var creado = await _appService.CreateAsync(tipoMascota);
                return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TipoMascota tipoMascota)
        {
            try
            {
                var actualizado = await _appService.UpdateAsync(id, tipoMascota);

                if (actualizado == null)
                    return NotFound(new { mensaje = $"TipoMascota con ID {id} no encontrado." });

                return Ok(actualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _appService.DeleteAsync(id);

            if (!resultado)
                return NotFound(new { mensaje = $"TipoMascota con ID {id} no encontrado." });

            return Ok(new { mensaje = $"TipoMascota con ID {id} inactivado correctamente." });
        }
    }
}
