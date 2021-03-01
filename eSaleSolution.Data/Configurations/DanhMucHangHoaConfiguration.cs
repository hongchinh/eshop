using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class DanhMucHangHoaConfiguration : IEntityTypeConfiguration<DanhMucHangHoa>
    {
        public void Configure(EntityTypeBuilder<DanhMucHangHoa> builder)
        {
            builder.ToTable("DanhMucHangHoa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}