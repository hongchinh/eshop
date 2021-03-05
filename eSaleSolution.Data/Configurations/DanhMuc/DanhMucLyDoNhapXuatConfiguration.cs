using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucLyDoNhapXuatConfiguration : IEntityTypeConfiguration<DanhMucLyDoNhapXuat>
    {
        public void Configure(EntityTypeBuilder<DanhMucLyDoNhapXuat> builder)
        {
            builder.ToTable("DanhMucLyDoNhapXuat");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}