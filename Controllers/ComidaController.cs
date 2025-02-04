using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComidaController : ControllerBase
    {
        private readonly IComidaService _service;

        public ComidaController(IComidaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comida>>> GetComidas()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comida>> GetComida(int id)
        {
            var comida = await _service.GetByIdAsync(id);
            if (comida == null) return NotFound();
            return Ok(comida);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComida(Comida comida)
        {
            await _service.AddAsync(comida);
            return CreatedAtAction(nameof(GetComida), new { id = comida.Id }, comida);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComida(int id, Comida comida)
        {
            await _service.UpdateAsync(comida);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComida(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
