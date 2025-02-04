using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioService _service;

        public ComentarioController(IComentarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> GetComentarios()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
            var comentario = await _service.GetByIdAsync(id);
            if (comentario == null) return NotFound();
            return Ok(comentario);
        }

        [HttpGet("pelicula/{peliculaId}")]
        public async Task<ActionResult<List<Comentario>>> GetComentariosByPelicula(int peliculaId)
        {
            return Ok(await _service.GetByPeliculaIdAsync(peliculaId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateComentario(Comentario comentario)
        {
            await _service.AddAsync(comentario);
            return CreatedAtAction(nameof(GetComentario), new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComentario(int id, Comentario comentario)
        {
            await _service.UpdateAsync(comentario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
