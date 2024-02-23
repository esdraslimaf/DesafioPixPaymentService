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
        Task<Transacao> AddTransacao(Transacao transacao);
        Task<ICollection<Transacao>> GetAllTransacoes();
        Task<Transacao> GetTransacaoById(Guid id);
        Task<Transacao> UpdateTransacao(Transacao transacao);
        Task<bool> DeleteTransacao(Guid id);
    }
}
