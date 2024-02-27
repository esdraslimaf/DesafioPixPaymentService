using APIPix.Data.Context;
using APIPix.Domain.Dtos.ChavePix;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

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
        public async Task<IActionResult> Post([FromBody] ChavePixDtoCreate dtoChavePixCreate)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            try
            {              
                return Ok(await _service.AddChave(dtoChavePixCreate));
            }
            catch (Exception erro)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, erro.Message);
            }
          
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllChaves());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetChavesById(id);

            if (result!=null)
            {             
                return Ok(result);
            }
            else
            {
                return NotFound(); // Retorna um código 404 caso não encontre a transação
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChaves(ChavePixDtoUpdate chavePixDtoUpdate)
        {
            return Ok(await _service.UpdateChaves(chavePixDtoUpdate));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.DeleteChaves(id));
        }
    }
}
