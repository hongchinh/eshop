using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class SoDuDauKyHangHoaConfiguration : IEntityTypeConfiguration<SoDuDauKyHangHoa>
    {
        public void Configure(EntityTypeBuilder<SoDuDauKyHangHoa> builder)
        {
            builder.ToTable("SoDuDauKyHangHoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
