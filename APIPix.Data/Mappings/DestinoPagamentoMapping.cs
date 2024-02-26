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
    public class DestinoPagamentoMapping : IEntityTypeConfiguration<Beneficiario>
    {
        public void Configure(EntityTypeBuilder<Beneficiario> builder)
        {
            builder.HasOne(o => o.ChavePix)
           .WithOne(cp=>cp.Recebedor)
           .HasForeignKey<Beneficiario>(c=>c.ChavePixId);


        }
    }
}
