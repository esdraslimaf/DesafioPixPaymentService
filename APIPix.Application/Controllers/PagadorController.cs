using APIPix.Domain.Dtos.Pagador;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace APIPix.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagadorController : ControllerBase
    {
        private readonly IOrigemPagamentoService _service;
        public PagadorController(IOrigemPagamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PagadorDtoCreate pagador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(await _service.AddOrigemPagamento(pagador));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllOrigensPagamentos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetOrigemPagamentoById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePagador(Guid id)
        {
            return Ok(await _service.DeleteOrigemPagamento(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePagador(PagadorDtoUpdate pagadorDtoUpdate)
        {
            return Ok(await _service.UpdateOrigemPagamento(pagadorDtoUpdate));
        }

    }
}
