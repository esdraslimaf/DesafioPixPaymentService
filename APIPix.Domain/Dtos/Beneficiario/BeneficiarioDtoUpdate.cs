using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Beneficiario
{
    public class BeneficiarioDtoUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Quantia { get; set; }
    }
}
