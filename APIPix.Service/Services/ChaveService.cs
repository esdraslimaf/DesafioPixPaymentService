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
            try
            {
                return await _repo.Add(chavePix);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<ChavePix> GetChavesById(Guid id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<ICollection<ChavePix>> GetAllChaves()
        {
            try
            {
                return await _repo.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ChavePix> UpdateChaves(ChavePix chavePix)
        {
            var existingEntity = await _repo.GetById(chavePix.Id);

            if (existingEntity == null)
            {
                return null;
            }

            existingEntity.TipoChavePix = chavePix.TipoChavePix;

            try
            {
              return await _repo.Update(existingEntity);           
            }
            catch (Exception)
            {
                throw;
            }


        }

        public async Task<bool> DeleteChaves(Guid id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
