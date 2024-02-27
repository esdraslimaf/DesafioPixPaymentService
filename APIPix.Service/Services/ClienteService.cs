using APIPix.Domain.Dtos.Cliente;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIPix.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IBaseRepository<Cliente> _repository;
        private readonly IMapper _mapper;

        public ClienteService(IBaseRepository<Cliente> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Cliente> AddCliente(ClienteDtoCreate clienteDtoCreate)
        {
            var cliente = _mapper.Map<Cliente>(clienteDtoCreate);

            if (cliente.Id == Guid.Empty)
            {
                cliente.Id = Guid.NewGuid();
            }

            try
            {
                return await _repository.Add(cliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteCliente(Guid id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<ClienteDtoResult>> GetAllClientes()
        {
            try
            {
                var entities = await _repository.GetAll();
                return _mapper.Map<ICollection<ClienteDtoResult>>(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteDtoResult> GetClienteById(Guid id)
        {
            try
            {
                return _mapper.Map<ClienteDtoResult>(await _repository.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cliente> UpdateCliente(ClienteDtoUpdate clienteDtoUpdate)
        {
            var existingEntity = await _repository.GetById(clienteDtoUpdate.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                existingEntity.Name = clienteDtoUpdate.Name;
                existingEntity.Saldo = clienteDtoUpdate.Saldo;
                return await _repository.Update(existingEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
