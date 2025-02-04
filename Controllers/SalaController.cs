using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _service;

        public SalaController(ISalaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sala>>> GetSalas()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> GetSala(int id)
        {
            var sala = await _service.GetByIdAsync(id);
            if (sala == null) return NotFound();
            return Ok(sala);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSala(Sala sala)
        {
            await _service.AddAsync(sala);
            return CreatedAtAction(nameof(GetSala), new { id = sala.Id }, sala);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSala(int id, Sala sala)
        {
            await _service.UpdateAsync(sala);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
