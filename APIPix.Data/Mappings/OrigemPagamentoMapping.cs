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
    public class OrigemPagamentoMapping : IEntityTypeConfiguration<OrigemPagamento>
    {
        public void Configure(EntityTypeBuilder<OrigemPagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(o => o.ChavePix)
            .WithOne(cp=>cp.Pagador)
            .HasForeignKey<OrigemPagamento>(o => o.ChavePixId);


        }
    }
}
