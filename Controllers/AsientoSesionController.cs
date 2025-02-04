using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoSesionController : ControllerBase
    {
        private readonly IAsientoSesionService _service;

        public AsientoSesionController(IAsientoSesionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AsientoSesion>>> GetAsientosSesion()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("sesion/{sesionId}")]
        public async Task<ActionResult<List<AsientoSesion>>> GetAsientosPorSesion(int sesionId)
        {
            return Ok(await _service.GetBySesionAsync(sesionId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsientoSesion(AsientoSesion asientoSesion)
        {
            await _service.AddAsync(asientoSesion);
            return Ok();
        }
    }
}
