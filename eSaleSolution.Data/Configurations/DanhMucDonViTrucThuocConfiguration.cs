﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eSaleSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucDonViTrucThuocConfiguration : IEntityTypeConfiguration<DanhMucDonViTrucThuoc>
    {
        public void Configure(EntityTypeBuilder<DanhMucDonViTrucThuoc> builder)
        {
            builder.ToTable("DanhMucDonViTrucThuoc");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
