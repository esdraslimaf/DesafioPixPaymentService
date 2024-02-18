using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IChaveService
    {
        Task<ChavePix> AddChave(ChavePix chavePix);
    }
}
