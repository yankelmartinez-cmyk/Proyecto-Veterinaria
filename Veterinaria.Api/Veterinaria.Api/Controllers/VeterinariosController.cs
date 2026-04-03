using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Infrastructure.Data.Repositories;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly VeterinarioRepository _repo;

        public VeterinariosController(VeterinarioRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var v = await _repo.GetByIdAsync(id);
            return v is null ? NotFound() : Ok(v);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veterinario veterinario)
        {
            await _repo.AddAsync(veterinario);
            return CreatedAtAction(nameof(GetById), new { id = veterinario.Id }, veterinario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Veterinario veterinario)
        {
            if (id != veterinario.Id) return BadRequest();
            await _repo.UpdateAsync(veterinario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}