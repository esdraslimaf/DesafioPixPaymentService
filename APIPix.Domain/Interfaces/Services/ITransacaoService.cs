using APIPix.Domain.Dtos.Transacao;
using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface ITransacaoService
    {
        Task<TransacaoDtoResult> AddTransacao(TransacaoDtoCreate transacaoDtoCreate);
        Task<ICollection<TransacaoDtoResult>> GetAllTransacoes();
        Task<Transacao> GetTransacaoById(Guid id);
        Task<TransacaoDtoResult> UpdateTransacao(TransacaoDtoUpdate transacao);
        Task<bool> DeleteTransacao(Guid id);
        Task<ICollection<TransacaoDtoResult>> GetTransacaoByPixId(Guid id);
    }
}
