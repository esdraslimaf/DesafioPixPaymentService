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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllChaves());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetChavesById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChaves(ChavePix chavePix)
        {
            return Ok(await _service.UpdateChaves(chavePix));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteChaves(id));
        }
    }
}
