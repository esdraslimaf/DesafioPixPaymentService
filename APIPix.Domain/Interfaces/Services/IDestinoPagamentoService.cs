using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IDestinoPagamentoService
    {
        Task<DestinoPagamento> AddDestinoPagamento(DestinoPagamento destinoPagamento);
        Task<ICollection<DestinoPagamento>> GetAllDestinosPagamentos();
        Task<DestinoPagamento> GetDestinoPagamentoById(Guid id);
        Task<DestinoPagamento> UpdateDestinoPagamento(DestinoPagamento destinoPagamento);
        Task<bool> DeleteDestinoPagamento(Guid id);
    }
}
