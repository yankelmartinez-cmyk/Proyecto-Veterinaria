using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Application.AppServices;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private readonly MascotaAppService _service;

        public MascotasController(MascotaAppService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mascota>>> Get()
        {
            var mascotas = await _service.GetAllAsync();
            return Ok(mascotas);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Mascota>> GetById(int id)
        {
            var mascota = await _service.GetByIdAsync(id);
            if (mascota == null) return NotFound();
            return Ok(mascota);
        }

        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Mascota mascota)
        {
            await _service.AddAsync(mascota);
            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Mascota mascota)
        {
            if (id != mascota.Id) return BadRequest();
            await _service.UpdateAsync(mascota);
            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}