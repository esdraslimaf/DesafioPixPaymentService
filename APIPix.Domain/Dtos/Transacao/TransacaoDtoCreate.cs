using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Transacao
{
    public class TransacaoDtoCreate
    {
        public Guid OrigemPagamentoId { get; set; }
        public Guid DestinoPagamentoId { get; set; }
        public double Valor { get; set; }
    }
}
