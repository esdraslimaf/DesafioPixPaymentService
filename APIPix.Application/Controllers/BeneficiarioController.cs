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
        public async Task<IActionResult> Post([FromBody] Beneficiario recebedor)
        {
            return Ok(await _service.AddDestinoPagamento(recebedor));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllDestinosPagamentos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetDestinoPagamentoById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecebedor(Guid id)
        {
            return Ok(await _service.DeleteDestinoPagamento(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRecebedor(Beneficiario recebedor)
        {
            return Ok(await _service.UpdateDestinoPagamento(recebedor));
        }
    }
}
