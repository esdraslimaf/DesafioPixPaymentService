using APIPix.Data.Context;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIPix.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChavesController:ControllerBase
    {
        private readonly IChaveService _service;
        public ChavesController(IChaveService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChavePix chave)
        {
            return Ok(await _service.AddChave(chave));
        }
    }
}
