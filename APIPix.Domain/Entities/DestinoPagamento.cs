using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Entities
{
    public class DestinoPagamento : BaseEntity
    {
        public string Name { get; set; }
        public Guid ChavePixId { get; set; }
        public ChavePix? ChavePix { get; set; }
        public ICollection<Transacao>? Transacoes { get; set; }
        public double Quantia { get; set; }
    }
}
