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
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBaseRepository<Beneficiario> _repository;
        public BeneficiarioService(IBaseRepository<Beneficiario> repository)
        {
            _repository = repository;
        }

        public async Task<Beneficiario> AddDestinoPagamento(Beneficiario destinoPagamento)
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

        public async Task<ICollection<Beneficiario>> GetAllDestinosPagamentos()
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

        public async Task<Beneficiario> GetDestinoPagamentoById(Guid id)
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

        public async Task<Beneficiario> UpdateDestinoPagamento(Beneficiario destinoPagamento)
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
