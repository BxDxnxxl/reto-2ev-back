using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Repositories;
using CineApi.Service;

namespace CineApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PeliculaController : ControllerBase
   {
    private static List<Pelicula> peliculas = new List<Pelicula>();

    private readonly IPeliculaService _servicPelicula;

    public PeliculaController(IPeliculaService service)
        {
            _servicPelicula = service;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> GetBebidas()
        {
            var peliculas = await _servicPelicula.GetAllAsync();
            return Ok(peliculas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetBebida(int id)
        {
            var peliculas = await _servicPelicula.GetByIdAsync(id);
            if (peliculas == null)
            {
                return NotFound();
            }
            return Ok(peliculas);
        }

        [HttpPost]
        public async Task<ActionResult<Pelicula>> CreateBebida(Pelicula peliculas)
        {
            await _servicPelicula.AddAsync(peliculas);
            return CreatedAtAction(nameof(GetBebida), new { id = peliculas.Id }, peliculas);
        }

       [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBebida(int id, Pelicula updatePelicula)
        {
            var existingPelicula = await _servicPelicula.GetByIdAsync(id);
            if (existingPelicula == null)
            {
                return NotFound();
            }

            // Actualizar el plato existente
            existingPelicula.Nombre = updatePelicula.Nombre;
            existingPelicula.Descripcion = updatePelicula.Descripcion;
            existingPelicula.Director = updatePelicula.Director;
            existingPelicula.AnioSalida = updatePelicula.AnioSalida;
            existingPelicula.ImagenBannerUrl = updatePelicula.ImagenBannerUrl;
            existingPelicula.ImagenPequeniaUrl = updatePelicula.ImagenPequeniaUrl;
            existingPelicula.Duracion = updatePelicula.Duracion;
            existingPelicula.Precio = updatePelicula.Precio;

            await _servicPelicula.UpdateAsync(existingPelicula);
            return NoContent();
        }

        ///Cambio necesario///
  
       [HttpDelete("{id}")]
       public async Task<IActionResult> DeletePlato(int id)
       {
           var pelicula = await _servicPelicula.GetByIdAsync(id);
           if (pelicula == null)
           {
               return NotFound();
           }
           await _servicPelicula.DeleteAsync(id);
           return NoContent();
       }

   }
}