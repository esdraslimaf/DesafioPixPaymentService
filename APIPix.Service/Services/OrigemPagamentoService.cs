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
    public class OrigemPagamentoService : IOrigemPagamentoService
    {
        private readonly IBaseRepository<OrigemPagamento> _repository;
        public OrigemPagamentoService(IBaseRepository<OrigemPagamento> repository)
        {
              _repository = repository;
        }


        public async Task<OrigemPagamento> AddOrigemPagamento(OrigemPagamento origemPagamento)
        {
            if (origemPagamento.Id == Guid.Empty) { origemPagamento.Id = Guid.NewGuid(); }
            try
            {
                return await _repository.Add(origemPagamento);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<bool> DeleteOrigemPagamento(Guid id)
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

        public async Task<ICollection<OrigemPagamento>> GetAllOrigensPagamentos()
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

        public async Task<OrigemPagamento> GetOrigemPagamentoById(Guid id)
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

        public async Task<OrigemPagamento> UpdateOrigemPagamento(OrigemPagamento origemPagamento)
        {
            var existingEntity = await _repository.GetById(origemPagamento.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                existingEntity.Name = origemPagamento.Name;
               return await _repository.Update(existingEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
