using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Application.AppServices;
using Veterinaria.Api.Domain.Entities;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly VeterinarioAppService _service;

        public VeterinariosController(VeterinarioAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var v = await _service.GetByIdAsync(id);
            return v is null ? NotFound() : Ok(v);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veterinario veterinario)
        {
            var creado = await _service.AddAsync(veterinario);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Veterinario veterinario)
        {
            var actualizado = await _service.UpdateAsync(id, veterinario);
            return actualizado is null ? NotFound() : Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.DeleteAsync(id);
            return resultado ? Ok() : NotFound();
        }
    }
}