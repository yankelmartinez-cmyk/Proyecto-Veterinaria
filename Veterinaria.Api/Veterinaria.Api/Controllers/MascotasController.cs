using Microsoft.AspNetCore.Mvc;
using Veterinaria.Api.Domain;
using Veterinaria.Api.Domain.Entities;
using Veterinaria.Api.Infrastructure.Repositories;

namespace Veterinaria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : ControllerBase
    {
        private readonly MascotaRepository _repository;

        public MascotasController(MascotaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Mascota>>> Get()
        {
            var mascotas = await _repository.GetAllAsync();
            return Ok(mascotas);
        }

        [HttpPost] 
        public async Task<ActionResult> Post([FromBody] Mascota mascota)
        {
            await _repository.AddAsync(mascota);
            return Ok();
        }
    }
}
