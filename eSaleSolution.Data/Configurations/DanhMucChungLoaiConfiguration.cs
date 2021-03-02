using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eSaleSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucChungLoaiConfiguration : IEntityTypeConfiguration<DanhMucChungLoai>
    {
        public void Configure(EntityTypeBuilder<DanhMucChungLoai> builder)
        {
            builder.ToTable("DanhMucChungLoai");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
