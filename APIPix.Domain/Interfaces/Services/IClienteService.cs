using APIPix.Domain.Dtos.Cliente;
using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Cliente> AddCliente(ClienteDtoCreate cliente);
        Task<bool> DeleteCliente(Guid id);
        Task<ICollection<ClienteDtoResult>> GetAllClientes();
        Task<ClienteDtoResult> GetClienteById(Guid id);
        Task<Cliente> UpdateCliente(ClienteDtoUpdate clienteDtoUpdate);
    }
}
