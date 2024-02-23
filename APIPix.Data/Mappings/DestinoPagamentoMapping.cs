using APIPix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Data.Mappings
{
    public class DestinoPagamentoMapping : IEntityTypeConfiguration<DestinoPagamento>
    {
        public void Configure(EntityTypeBuilder<DestinoPagamento> builder)
        {
            builder.HasOne(o => o.ChavePix)
           .WithOne(cp=>cp.Recebedor)
           .HasForeignKey<DestinoPagamento>(c=>c.ChavePixId);


        }
    }
}
