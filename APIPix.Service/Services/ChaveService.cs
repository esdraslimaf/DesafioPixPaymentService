using APIPix.Domain.Dtos.ChavePix;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ChaveService(IBaseRepository<ChavePix> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ChavePix> AddChave(ChavePixDtoCreate dtoChavePixCreate)
        {
            try
            {
                var chavePix = _mapper.Map<ChavePix>(dtoChavePixCreate);
                if (chavePix.Id == Guid.Empty) { chavePix.Id = Guid.NewGuid(); }
                return await _repo.Add(chavePix);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ChavePixDtoResult> GetChavesById(Guid id)
        {
            try
            {
                var result = await _repo.GetById(id);
                return _mapper.Map<ChavePixDtoResult>(result);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ICollection<ChavePixDtoResult>> GetAllChaves()
        {
            try
            {
                var result = await _repo.GetAll();
                return _mapper.Map<ICollection<ChavePixDtoResult>>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ChavePixDtoUpdate> UpdateChaves(ChavePixDtoUpdate chavePixDtoUpdate)
        {
            var existingEntity = await _repo.GetById(chavePixDtoUpdate.Id);

            if (existingEntity == null)
            {
                return null;
            }

            existingEntity.TipoChavePix = chavePixDtoUpdate.TipoChavePix;

            try
            {
                var result = await _repo.Update(existingEntity);
                return _mapper.Map<ChavePixDtoUpdate>(result);
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
