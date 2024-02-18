using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Entities
{
    public class OrigemPagamento : BaseEntity
    {      
        public ChavePix Chave { get; set; }
        public string Name { get; set; }
        public ICollection<Transacao> Transacoes { get; set; }
    }
}
