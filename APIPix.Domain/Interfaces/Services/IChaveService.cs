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
        Task<ICollection<ChavePix>> GetAllChaves();
        Task<ChavePix> GetChavesById(Guid id);
        Task<ChavePix> UpdateChaves(ChavePix chavePix);
        Task<bool> DeleteChaves(Guid id);
    }
}
