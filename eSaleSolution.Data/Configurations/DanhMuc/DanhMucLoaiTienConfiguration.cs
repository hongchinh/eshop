using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucLoaiTonConfiguration : IEntityTypeConfiguration<DanhMucLoaiTon>
    {
        public void Configure(EntityTypeBuilder<DanhMucLoaiTon> builder)
        {
            builder.ToTable("DanhMucLoaiTon");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}