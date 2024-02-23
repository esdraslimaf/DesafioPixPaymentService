using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.ChavePix
{
    public class ChavePixDtoUpdate
    {
        public Guid Id { get; set; }
        public EnumTipoChavePix TipoChavePix { get; set; }
    }
}
