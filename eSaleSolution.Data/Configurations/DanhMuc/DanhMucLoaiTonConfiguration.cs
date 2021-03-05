using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucLoaiTienConfiguration : IEntityTypeConfiguration<DanhMucLoaiTien>
    {
        public void Configure(EntityTypeBuilder<DanhMucLoaiTien> builder)
        {
            builder.ToTable("DanhMucLoaiTien");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}