using APIPix.Domain.Dtos.Beneficiario;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIPix.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeneficiarioController : ControllerBase
    {
        private readonly IBeneficiarioService _service;

        public BeneficiarioController(IBeneficiarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BeneficiarioDtoCreate recebedor)
        {
            return Ok(await _service.AddBeneficiario(recebedor));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllBeneficiarios());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetBeneficiarioById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecebedor(Guid id)
        {
            return Ok(await _service.DeleteBeneficiario(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecebedor(BeneficiarioDtoUpdate recebedor)
        {
            return Ok(await _service.UpdateBeneficiario(recebedor));
        }
    }
}
