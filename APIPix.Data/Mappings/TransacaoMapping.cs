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

            builder.HasOne(t => t.OrigemPagamento)
                   .WithMany(o => o.Transacoes).HasForeignKey(t => t.OrigemPagamentoId);

            builder.HasOne(t => t.DestinoPagamento)
                   .WithMany(d => d.Transacoes).HasForeignKey(t => t.DestinoPagamentoId);

        }
    }
}
