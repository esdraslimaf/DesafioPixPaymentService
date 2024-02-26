using APIPix.Domain.Dtos.Pagador;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APIPix.Service.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly IBaseRepository<Transacao> _repository;
        private readonly IDestinoPagamentoService _destinoPagamentoService;
        private readonly IPagadorService _origemPagamentoService;
        private readonly IMapper _mapper;

        public TransacaoService(IBaseRepository<Transacao> repository, IDestinoPagamentoService destinoPagamentoService, IPagadorService origemPagamentoService, IMapper mapper)
        {
            _repository = repository;
            _destinoPagamentoService = destinoPagamentoService;
            _origemPagamentoService = origemPagamentoService;
            _mapper = mapper;
        }

        public async Task<Transacao> AddTransacao(Transacao transacao)
        {
            if (transacao.Id == Guid.Empty)
            {
                transacao.Id = Guid.NewGuid();
            }
            try
            {
                var origem = _mapper.Map<Pagador>(await _origemPagamentoService.GetOrigemPagamentoById(transacao.OrigemPagamentoId));               
                var destino = await _destinoPagamentoService.GetDestinoPagamentoById(transacao.DestinoPagamentoId);



                origem.Quantia -= transacao.Valor;
                destino.Quantia += transacao.Valor;

                

                _origemPagamentoService.UpdateOrigemPagamento(_mapper.Map<PagadorDtoUpdate>(origem));


                _destinoPagamentoService.UpdateDestinoPagamento(destino);

                return await _repository.Add(transacao);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTransacao(Guid id)
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

        public async Task<ICollection<Transacao>> GetAllTransacoes()
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

        public async Task<Transacao> GetTransacaoById(Guid id)
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

        public async Task<Transacao> UpdateTransacao(Transacao transacao)
        {
            var existingEntity = await _repository.GetById(transacao.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                // Atualize as propriedades conforme necessário
                existingEntity.DestinoPagamentoId= transacao.DestinoPagamentoId;
                existingEntity.OrigemPagamentoId = transacao.OrigemPagamentoId;

                return await _repository.Update(existingEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}