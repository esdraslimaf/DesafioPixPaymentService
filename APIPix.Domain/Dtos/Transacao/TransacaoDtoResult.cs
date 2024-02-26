using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Transacao
{
    public class TransacaoDtoResult
    {
        public Guid Id { get; set; }
        public DateTime Horario { get; set; }
        public Guid OrigemPagamentoId { get; set; }
        public Guid DestinoPagamentoId { get; set; }
        public double Valor { get; set; }
        
    }
}
