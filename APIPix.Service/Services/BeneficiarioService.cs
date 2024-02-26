using APIPix.Domain.Dtos.Beneficiario;
using APIPix.Domain.Entities;
using APIPix.Domain.Interfaces;
using APIPix.Domain.Interfaces.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIPix.Service.Services
{
    public class BeneficiarioService : IBeneficiarioService
    {
        private readonly IBaseRepository<Beneficiario> _repository;
        private readonly IMapper _mapper;

        public BeneficiarioService(IBaseRepository<Beneficiario> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Beneficiario> AddBeneficiario(BeneficiarioDtoCreate beneficiarioDtoCreate)
        {
            var beneficiario = _mapper.Map<Beneficiario>(beneficiarioDtoCreate);

            if (beneficiario.Id == Guid.Empty)
            {
                beneficiario.Id = Guid.NewGuid();
            }

            try
            {
                return await _repository.Add(beneficiario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteBeneficiario(Guid id)
        {
            try
            {
                return await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ICollection<BeneficiarioDtoResult>> GetAllBeneficiarios()
        {
            try
            {
                var entities = await _repository.GetAll();
                return _mapper.Map<ICollection<BeneficiarioDtoResult>>(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BeneficiarioDtoResult> GetBeneficiarioById(Guid id)
        {
            try
            {
                return _mapper.Map<BeneficiarioDtoResult>(await _repository.GetById(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Beneficiario> UpdateBeneficiario(BeneficiarioDtoUpdate beneficiarioDtoUpdate)
        {
            var existingEntity = await _repository.GetById(beneficiarioDtoUpdate.Id);

            if (existingEntity == null)
            {
                return null;
            }

            try
            {
                existingEntity.Name = beneficiarioDtoUpdate.Name;
                existingEntity.Quantia = beneficiarioDtoUpdate.Quantia;
                return await _repository.Update(existingEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
