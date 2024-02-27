using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Domain.Dtos.Cliente
{
    public class ClienteDtoCreate
    {
        [Required(ErrorMessage = "O campo Name é obrigatório. Insira um existente!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo ChavePix é obrigatório. Insira um existente!!")]
        public Guid? ChavePixId { get; set; }
        public double Saldo { get; set; }
    }
}
