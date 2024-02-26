using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IBeneficiarioService
    {
        Task<Beneficiario> AddDestinoPagamento(Beneficiario destinoPagamento);
        Task<ICollection<Beneficiario>> GetAllDestinosPagamentos();
        Task<Beneficiario> GetDestinoPagamentoById(Guid id);
        Task<Beneficiario> UpdateDestinoPagamento(Beneficiario destinoPagamento);
        Task<bool> DeleteDestinoPagamento(Guid id);
    }
}
