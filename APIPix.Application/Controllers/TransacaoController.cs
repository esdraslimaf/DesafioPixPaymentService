using APIPix.Domain.Dtos.Transacao;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace APIPix.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _service;

        public TransacaoController(ITransacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TransacaoDtoCreate transacaoDtoCreate)
        {
            return Ok(await _service.AddTransacao(transacaoDtoCreate));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllTransacoes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetTransacaoById(id));
        }

        [HttpGet("BuscarTransacoesPorChavePix")]
        public async Task<IActionResult> GetByIdPix(Guid id)
        {
            return Ok(await _service.GetTransacaoByPixId(id));
        }
 
        [HttpPut]
        public async Task<IActionResult> UpdateTransacao(TransacaoDtoUpdate transacao)
        {
            return Ok(await _service.UpdateTransacao(transacao));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteTransacao(id));
        }
    }
}
