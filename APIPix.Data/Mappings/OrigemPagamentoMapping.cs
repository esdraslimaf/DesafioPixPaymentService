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
    public class OrigemPagamentoMapping : IEntityTypeConfiguration<Pagador>
    {
        public void Configure(EntityTypeBuilder<Pagador> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(o => o.ChavePix)
            .WithOne(cp=>cp.Pagador)
            .HasForeignKey<Pagador>(o => o.ChavePixId);


        }
    }
}
