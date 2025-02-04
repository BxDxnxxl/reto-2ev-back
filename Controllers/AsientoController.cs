using Microsoft.AspNetCore.Mvc;
using Models;
using CineApi.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsientoController : ControllerBase
    {
        private readonly IAsientoService _service;

        public AsientoController(IAsientoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Asiento>>> GetAsientos()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsiento(Asiento asiento)
        {
            await _service.AddAsync(asiento);
            return Ok();
        }
    }
}
