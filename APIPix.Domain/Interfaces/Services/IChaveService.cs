using APIPix.Domain.Dtos.ChavePix;
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
        Task<ChavePix> AddChave(ChavePixDtoCreate dtoChavePixCreate);
        Task<ICollection<ChavePixDtoResult>> GetAllChaves();
        Task<ChavePixDtoResult> GetChavesById(Guid id);
        Task<ChavePixDtoUpdate> UpdateChaves(ChavePixDtoUpdate chavePix);
        Task<bool> DeleteChaves(Guid id);
    }
}
