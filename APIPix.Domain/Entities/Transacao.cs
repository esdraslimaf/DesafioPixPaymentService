using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Entities
{
    public class Transacao: BaseEntity
    {
        public DateTime Horario { get; set; }
        public OrigemPagamento OrigemPagamento { get; set; }
        public int OrigemPagamentoId { get; set; }
        public DestinoPagamento DestinoPagamento { get; set; }
        public int DestinoPagamentoId { get; set; }

    }
}
