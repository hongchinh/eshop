using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class ChungTuConfiguration : IEntityTypeConfiguration<ChungTu>
    {
        public void Configure(EntityTypeBuilder<ChungTu> builder)
        {
            builder.ToTable("ChungTu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
