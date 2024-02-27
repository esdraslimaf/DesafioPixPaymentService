using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace APIPix.Domain.Entities
{
    public class ChavePix: BaseEntity
    {
        public EnumTipoChavePix TipoChavePix { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
