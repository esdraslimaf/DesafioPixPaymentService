using APIPix.Domain.Dtos.Beneficiario;
using APIPix.Domain.Dtos.Pagador;
using APIPix.Domain.Dtos.Transacao;
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
        private readonly IBeneficiarioService _destinoPagamentoService;
        private readonly IPagadorService _origemPagamentoService;
        private readonly IMapper _mapper;

        public TransacaoService(IBaseRepository<Transacao> repository, IBeneficiarioService destinoPagamentoService, IPagadorService origemPagamentoService, IMapper mapper)
        {
            _repository = repository;
            _destinoPagamentoService = destinoPagamentoService;
            _origemPagamentoService = origemPagamentoService;
            _mapper = mapper;
        }

        public async Task<TransacaoDtoResult> AddTransacao(TransacaoDtoCreate transacaoDtoCreate)
        {
            Transacao transacao = _mapper.Map<Transacao>(transacaoDtoCreate);

            if (transacao.Id == Guid.Empty)
            {
                transacao.Id = Guid.NewGuid();
            }
            try
            {
                transacao.Horario = DateTime.UtcNow;

                // Obtém o pagador e atualiza sua quantia subtraindo o valor da transação.
                var pagador = await _origemPagamentoService.GetOrigemPagamentoById(transacao.OrigemPagamentoId);
                pagador.Quantia -= transacao.Valor;
                var entidadePagador = _mapper.Map<Pagador>(pagador);

                // Obtém o beneficiário e atualiza sua quantia adicionando o valor da transação.
                var beneficiario = await _destinoPagamentoService.GetBeneficiarioById(transacao.DestinoPagamentoId);
                beneficiario.Quantia += transacao.Valor;
                var entidadeBeneficiario = _mapper.Map<Beneficiario>(beneficiario);

                // Atualiza as informações do pagador e beneficiário nos respectivos serviços.
                await _origemPagamentoService.UpdateOrigemPagamento(_mapper.Map<PagadorDtoUpdate>(entidadePagador));
                await _destinoPagamentoService.UpdateBeneficiario(_mapper.Map<BeneficiarioDtoUpdate>(entidadeBeneficiario));


                //Adiciona a transação no banco de dados
                var result = await _repository.Add(transacao);

                //Retorna um TransacaoDtoResult
                return _mapper.Map<TransacaoDtoResult>(result);
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

        public async Task<ICollection<TransacaoDtoResult>> GetAllTransacoes()
        {
            try
            {
                var result = await _repository.GetAll();
                return _mapper.Map<ICollection<TransacaoDtoResult>>(result);
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

        public async Task<TransacaoDtoResult> UpdateTransacao(TransacaoDtoUpdate transacaoDtoUpdate)
        {
            var existingEntity = await _repository.GetById(transacaoDtoUpdate.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                // Atualize as propriedades conforme necessário
                existingEntity.Horario = transacaoDtoUpdate.Horario;
                var result = await _repository.Update(existingEntity);
                return _mapper.Map<TransacaoDtoResult>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}