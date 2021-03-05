using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class SoDuDauKyDoiTuongConfiguration : IEntityTypeConfiguration<SoDuDauKyDoiTuong>
    {
        public void Configure(EntityTypeBuilder<SoDuDauKyDoiTuong> builder)
        {
            builder.ToTable("SoDuDauKyDoiTuong");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
