using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Pagador
{
    public class PagadorDtoUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Quantia { get; set; }

    }
}
