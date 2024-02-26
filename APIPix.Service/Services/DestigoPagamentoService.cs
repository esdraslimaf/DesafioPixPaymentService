using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Service.Services
{
    public class DestinoPagamentoService : IDestinoPagamentoService
    {
        private readonly IBaseRepository<DestinoPagamento> _repository;
        public DestinoPagamentoService(IBaseRepository<DestinoPagamento> repository)
        {
            _repository = repository;
        }

        public async Task<DestinoPagamento> AddDestinoPagamento(DestinoPagamento destinoPagamento)
        {
            if (destinoPagamento.Id == Guid.Empty)
            {
                destinoPagamento.Id = Guid.NewGuid();
            }
            try
            { 
                return await _repository.Add(destinoPagamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDestinoPagamento(Guid id)
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

        public async Task<ICollection<DestinoPagamento>> GetAllDestinosPagamentos()
        {
            try
            {
                return await _repository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DestinoPagamento> GetDestinoPagamentoById(Guid id)
        {
            try
            {
                return await _repository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DestinoPagamento> UpdateDestinoPagamento(DestinoPagamento destinoPagamento)
        {
            var existingEntity = await _repository.GetById(destinoPagamento.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                existingEntity.Name = destinoPagamento.Name;
                return await _repository.Update(existingEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    }
