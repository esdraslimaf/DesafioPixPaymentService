using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Entities
{
    public class Transacao:BaseEntity
    {
        public DateTime Horario { get; set; }
        public Cliente? Pagador { get; set; }
        public Guid PagadorId { get; set; }
        public Cliente? Beneficiario { get; set; }
        public Guid BeneficiarioId { get; set; }
        public double Valor { get; set; }

    }
}
