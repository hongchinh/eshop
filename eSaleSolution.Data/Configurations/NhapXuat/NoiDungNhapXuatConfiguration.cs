using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.Configurations
{
    public class NoiDungNhapXuatConfiguration : IEntityTypeConfiguration<NoiDungNhapXuat>
    {
        public void Configure(EntityTypeBuilder<NoiDungNhapXuat> builder)
        {
            builder.ToTable("NoiDungNhapXuat");

            builder.HasKey(x => x.IdId);

            builder.Property(x => x.IdId).UseIdentityColumn();
        }
    }
}
