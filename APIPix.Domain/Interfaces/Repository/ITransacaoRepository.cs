using APIPix.Domain.Dtos.Transacao;
using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Repository
{
    public interface ITransacaoRepository:IBaseRepository<Transacao>
    {
        Task<ICollection<TransacaoDtoResult>> GetTransacoesByPixId(Guid id);
    }
}
