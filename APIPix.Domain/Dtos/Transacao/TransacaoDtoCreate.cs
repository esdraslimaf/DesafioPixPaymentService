using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Transacao
{
    public class TransacaoDtoCreate
    {
        public Guid PagadorId { get; set; }
        public Guid BeneficiarioId { get; set; }
        public double Valor { get; set; }
    }
}
