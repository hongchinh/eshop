using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucHinhThucTTConfiguration : IEntityTypeConfiguration<DanhMucHinhThucTT>
    {
        public void Configure(EntityTypeBuilder<DanhMucHinhThucTT> builder)
        {
            builder.ToTable("DanhMucHinhThucTT");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}