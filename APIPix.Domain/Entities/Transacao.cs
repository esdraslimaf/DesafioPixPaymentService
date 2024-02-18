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
        public OrigemPagamento? OrigemPagamento { get; set; }
        public Guid? OrigemPagamentoId { get; set; }
        public DestinoPagamento? DestinoPagamento { get; set; }
        public Guid? DestinoPagamentoId { get; set; }

    }
}
