using APIPix.Data.Context;
using APIPix.Domain.Dtos.Transacao;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Data.Repository
{
    public class TransacaoRepository : BaseRepository<Transacao>, ITransacaoRepository
    {
        private readonly MyContext _context;
        private readonly IMapper _mapper;

        public TransacaoRepository(MyContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        //    return await _context.Transacoes.Where(t => t.Pagador.ChavePixId == id || t.Beneficiario.ChavePixId == id).ToListAsync();
        public async Task<ICollection<TransacaoDtoResult>> GetTransacoesByPixId(Guid id)
        {
            var result = await _context.Transacoes
                  .Include(t => t.Pagador)
                      .ThenInclude(c => c.ChavePix)
                  .Include(t => t.Beneficiario)
                      .ThenInclude(c => c.ChavePix)
                  .Where(t => t.Pagador.ChavePix.Id == id || t.Beneficiario.ChavePix.Id == id)
                  .ToListAsync();
            return _mapper.Map<ICollection<TransacaoDtoResult>>(result);

        }
    }
}
