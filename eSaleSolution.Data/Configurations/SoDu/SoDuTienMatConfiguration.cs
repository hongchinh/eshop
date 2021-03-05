using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class SoDuTienMatConfiguration : IEntityTypeConfiguration<SoDuTienMat>
    {
        public void Configure(EntityTypeBuilder<SoDuTienMat> builder)
        {
            builder.ToTable("SoDuTienMat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
