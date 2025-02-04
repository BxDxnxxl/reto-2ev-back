using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _service;

        public CompraController(ICompraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Compra>>> GetCompras()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _service.GetByIdAsync(id);
            if (compra == null) return NotFound();
            return Ok(compra);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompra(Compra compra)
        {
            await _service.AddAsync(compra);
            return CreatedAtAction(nameof(GetCompra), new { id = compra.Id }, compra);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompra(int id, Compra compra)
        {
            await _service.UpdateAsync(compra);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
