using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class BaoCaoConfiguration : IEntityTypeConfiguration<BaoCao>
    {
        public void Configure(EntityTypeBuilder<BaoCao> builder)
        {
            builder.ToTable("BaoCao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
