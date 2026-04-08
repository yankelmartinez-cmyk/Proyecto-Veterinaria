using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteAppService _appService;

        public ClientesController(ClienteAppService appService)
        {
            _appService = appService;
        }

        // GET: api/clientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _appService.GetAllAsync();
            return Ok(clientes);
        }

        // GET: api/clientes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _appService.GetByIdAsync(id);
            if (cliente == null)
                return NotFound(new { mensaje = $"Cliente con ID {id} no encontrado." });

            return Ok(cliente);
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            try
            {
                var creado = await _appService.CreateAsync(cliente);
                return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var actualizado = await _appService.UpdateAsync(id, cliente);
                if (actualizado == null)
                    return NotFound(new { mensaje = $"Cliente con ID {id} no encontrado." });

                return Ok(actualizado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _appService.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = $"Cliente con ID {id} no encontrado." });

            return Ok(new { mensaje = $"Cliente con ID {id} inactivado correctamente." });
        }
    }
}
