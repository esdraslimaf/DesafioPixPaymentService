using APIPix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<ChavePix> Chaves { get; set; }
        DbSet<DestinoPagamento> DestinosPagamentos { get; set; }
        DbSet<OrigemPagamento> OrigensPagamentos { get;set; }
        DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
            base.OnModelCreating(modelBuilder); 
        }

    }
}
