using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Entities
{
    public class Cliente:BaseEntity
    {
        public string Name { get; set; }
        public Guid ChavePixId { get; set; }
        public ChavePix? ChavePix { get; set; }
        public double Saldo { get; set; }

        [NotMapped]
        public ICollection<Transacao>? Transacoes { get; set; }
        //A prop acima não recomendo ser mapeada, pois poderá ocasionar ambiguiadade já que em Transação tem 2 FK para Cliente

       
    }
}
