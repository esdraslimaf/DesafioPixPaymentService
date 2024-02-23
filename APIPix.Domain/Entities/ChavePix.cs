using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace APIPix.Domain.Entities
{
    public class ChavePix: BaseEntity
    {
        public EnumTipoChavePix TipoChavePix { get; set; }
        public OrigemPagamento? Pagador { get; set; }
        public DestinoPagamento? Recebedor { get; set; } 
    }
}
