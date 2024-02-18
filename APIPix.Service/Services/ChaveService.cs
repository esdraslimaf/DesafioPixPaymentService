using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Service.Services
{
    public class ChaveService : IChaveService
    {
        private readonly IBaseRepository<ChavePix> _repo;

        public ChaveService(IBaseRepository<ChavePix> repo)
        {
            _repo = repo;
        }

        public async Task<ChavePix> AddChave(ChavePix chavePix)
        {
            return await _repo.Add(chavePix);
        }
    }
}
