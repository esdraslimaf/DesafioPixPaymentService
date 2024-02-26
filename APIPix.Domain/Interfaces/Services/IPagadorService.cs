using APIPix.Domain.Dtos.Pagador;
using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IPagadorService
    {
        Task<Pagador> AddOrigemPagamento(PagadorDtoCreate origemPagamento);
        Task<bool> DeleteOrigemPagamento(Guid id);
        Task<ICollection<PagadorDtoResult>> GetAllOrigensPagamentos();
        Task<PagadorDtoResult> GetOrigemPagamentoById(Guid id);
        Task<Pagador> UpdateOrigemPagamento(PagadorDtoUpdate PagadorDtoUpdate);
    }
}
