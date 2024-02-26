using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Entities
{
    public class Pagador : BaseEntity
    {
        public string Name { get; set; }
        public Guid ChavePixId { get; set; }
        public ChavePix? ChavePix { get; set; }
        public ICollection<Transacao>? Transacoes { get; set; }
        public double Quantia { get; set; }
    }
}
