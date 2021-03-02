using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eSaleSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucDoDayConfiguration : IEntityTypeConfiguration<DanhMucDoDay>
    {
        public void Configure(EntityTypeBuilder<DanhMucDoDay> builder)
        {
            builder.ToTable("DanhMucDoDay");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
