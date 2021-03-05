using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class NhapXuatConfiguration : IEntityTypeConfiguration<NhapXuat>
    {
        public void Configure(EntityTypeBuilder<NhapXuat> builder)
        {
            builder.ToTable("NhapXuat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
