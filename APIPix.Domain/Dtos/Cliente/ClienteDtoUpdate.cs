using APIPix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Cliente
{
    public class ClienteDtoUpdate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Saldo { get; set; }

    }
}
