using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Beneficiario
{
    public class BeneficiarioDtoResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Quantia { get; set; }
        public Guid ChavePixId { get; set; }
    }
}
