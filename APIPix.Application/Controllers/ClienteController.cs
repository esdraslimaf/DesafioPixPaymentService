using APIPix.Domain.Dtos.Cliente;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace APIPix.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDtoCreate cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _service.AddCliente(cliente));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllClientes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetClienteById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            return Ok(await _service.DeleteCliente(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente(ClienteDtoUpdate clienteDtoUpdate)
        {
            return Ok(await _service.UpdateCliente(clienteDtoUpdate));
        }
    }
}
