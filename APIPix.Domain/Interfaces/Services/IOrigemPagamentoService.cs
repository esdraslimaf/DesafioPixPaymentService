using APIPix.Domain.Dtos.Pagador;
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
        Task<OrigemPagamento> AddOrigemPagamento(PagadorDtoCreate origemPagamento);
        Task<bool> DeleteOrigemPagamento(Guid id);
        Task<ICollection<PagadorDtoResult>> GetAllOrigensPagamentos();
        Task<PagadorDtoResult> GetOrigemPagamentoById(Guid id);
        Task<OrigemPagamento> UpdateOrigemPagamento(PagadorDtoUpdate PagadorDtoUpdate);
    }
}
