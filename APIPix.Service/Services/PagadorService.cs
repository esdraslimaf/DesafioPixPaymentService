using APIPix.Domain.Dtos.Pagador;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Service.Services
{
    public class PagadorService : IPagadorService
    {
        private readonly IBaseRepository<Pagador> _repository;
        private readonly IMapper _mapper;
        public PagadorService(IBaseRepository<Pagador> repository, IMapper mapper)
        {
              _repository = repository;
            _mapper = mapper;
        }


        public async Task<Pagador> AddOrigemPagamento(PagadorDtoCreate pagadorDtoCreate)          
        {
            var origemPagamento = _mapper.Map<Pagador>(pagadorDtoCreate);

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

        public async Task<ICollection<PagadorDtoResult>> GetAllOrigensPagamentos()
        {
            try
            {
                var entities = await _repository.GetAll();
                return _mapper.Map<ICollection<PagadorDtoResult>>(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagadorDtoResult> GetOrigemPagamentoById(Guid id)
        {
            try
            {
                return _mapper.Map<PagadorDtoResult>(await _repository.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pagador> UpdateOrigemPagamento(PagadorDtoUpdate PagadorDtoUpdate)
        {

            var existingEntity = await _repository.GetById(PagadorDtoUpdate.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                existingEntity.Name = PagadorDtoUpdate.Name;
                existingEntity.Quantia = PagadorDtoUpdate.Quantia;
               return await _repository.Update(existingEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
