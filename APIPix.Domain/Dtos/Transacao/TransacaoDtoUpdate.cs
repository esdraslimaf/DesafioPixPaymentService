using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Transacao
{
    public class TransacaoDtoUpdate
    {
        public Guid Id { get; set; }
        public DateTime Horario { get; set; }
    }
}
