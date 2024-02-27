using APIPix.Domain.Dtos.Cliente;
using APIPix.Domain.Dtos.Transacao;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Repository;
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
        private readonly ITransacaoRepository _repository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public TransacaoService(ITransacaoRepository repository, IClienteService clienteService, IMapper mapper)
        {
            _repository = repository;
            _clienteService = clienteService;
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

                // Obtém o cliente pagador por meio da chave pix e atualiza sua quantia adicionando o valor da transação.             
                                                        
                var pagador = await _clienteService.GetClienteById(transacao.PagadorId);
                pagador.Saldo -= transacao.Valor;
                var entidadePagador = _mapper.Map<Cliente>(pagador);

                // Obtém o cliente beneficiário e atualiza sua quantia adicionando o valor da transação.
                var beneficiario = await _clienteService.GetClienteById(transacao.BeneficiarioId);
                beneficiario.Saldo += transacao.Valor;
                var entidadeBeneficiario = _mapper.Map<Cliente>(beneficiario);

                // Atualiza as informações do pagador e beneficiário nos respectivos serviços.
                await _clienteService.UpdateCliente(_mapper.Map<ClienteDtoUpdate>(entidadePagador));
                await _clienteService.UpdateCliente(_mapper.Map<ClienteDtoUpdate>(entidadeBeneficiario));

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

        public async Task<ICollection<TransacaoDtoResult>> GetTransacaoByPixId(Guid id)
        {
            return await _repository.GetTransacoesByPixId(id);
        }
    }
}
