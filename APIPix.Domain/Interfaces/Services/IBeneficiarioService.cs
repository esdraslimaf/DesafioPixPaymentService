using APIPix.Domain.Dtos.Beneficiario;
using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIPix.Domain.Interfaces.Services
{
    public interface IBeneficiarioService
    {
        Task<Beneficiario> AddBeneficiario(BeneficiarioDtoCreate beneficiario);
        Task<bool> DeleteBeneficiario(Guid id);
        Task<ICollection<BeneficiarioDtoResult>> GetAllBeneficiarios();
        Task<BeneficiarioDtoResult> GetBeneficiarioById(Guid id);
        Task<Beneficiario> UpdateBeneficiario(BeneficiarioDtoUpdate beneficiarioDtoUpdate);
    }
}
