using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private readonly ISesionService _service;

        public SesionController(ISesionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sesion>>> GetSesiones()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sesion>> GetSesion(int id)
        {
            var sesion = await _service.GetByIdAsync(id);
            if (sesion == null) return NotFound();
            return Ok(sesion);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSesion(Sesion sesion)
        {
            await _service.AddAsync(sesion);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSesion(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
