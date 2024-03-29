﻿using APIPix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPix.Data.Mappings
{
    public class ChaveMapping : IEntityTypeConfiguration<ChavePix>
    {
        public void Configure(EntityTypeBuilder<ChavePix> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=>c.TipoChavePix).IsRequired();
        }
    }
}
