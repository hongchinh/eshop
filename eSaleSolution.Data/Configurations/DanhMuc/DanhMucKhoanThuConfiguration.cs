using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucKhoanThuConfiguration : IEntityTypeConfiguration<DanhMucKhoanThu>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhoanThu> builder)
        {
            builder.ToTable("DanhMucKhoanThu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}