using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucKhoanChiConfiguration : IEntityTypeConfiguration<DanhMucKhoanChi>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhoanChi> builder)
        {
            builder.ToTable("DanhMucKhoanChi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}