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
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.OrigemPagamento).WithMany(t => t.Transacoes).IsRequired();
            builder.HasOne(t => t.DestinoPagamento).WithMany(t => t.Transacoes).IsRequired();

        }
    }
}
