using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlimentoController : ControllerBase
    {
        private readonly ITipoAlimentoService _service;

        public TipoAlimentoController(ITipoAlimentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoAlimento>>> GetTiposAlimentos()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoAlimento>> GetTipoAlimento(int id)
        {
            var tipoAlimento = await _service.GetByIdAsync(id);
            if (tipoAlimento == null) return NotFound();
            return Ok(tipoAlimento);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTipoAlimento(TipoAlimento tipoAlimento)
        {
            await _service.AddAsync(tipoAlimento);
            return CreatedAtAction(nameof(GetTipoAlimento), new { id = tipoAlimento.Id }, tipoAlimento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoAlimento(int id, TipoAlimento tipoAlimento)
        {
            await _service.UpdateAsync(tipoAlimento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoAlimento(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
