using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucTinhTrangConfiguration : IEntityTypeConfiguration<DanhMucTinhTrang>
    {
        public void Configure(EntityTypeBuilder<DanhMucTinhTrang> builder)
        {
            builder.ToTable("DanhMucTinhTrang");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}