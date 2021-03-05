using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucLoaiNhapXuatConfiguration : IEntityTypeConfiguration<DanhMucLoaiNhapXuat>
    {
        public void Configure(EntityTypeBuilder<DanhMucLoaiNhapXuat> builder)
        {
            builder.ToTable("DanhMucLoaiNhapXuat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}