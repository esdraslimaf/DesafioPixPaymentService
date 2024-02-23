using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IOrigemPagamentoService
    {
        Task<OrigemPagamento> AddOrigemPagamento(OrigemPagamento origemPagamento);
        Task<bool> DeleteOrigemPagamento(Guid id);
        Task<ICollection<OrigemPagamento>> GetAllOrigensPagamentos();
        Task<OrigemPagamento> GetOrigemPagamentoById(Guid id);
        Task<OrigemPagamento> UpdateOrigemPagamento(OrigemPagamento origemPagamento);
    }
}
