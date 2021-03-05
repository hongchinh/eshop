using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucKhuVucConfiguration : IEntityTypeConfiguration<DanhMucKhuVuc>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhuVuc> builder)
        {
            builder.ToTable("DanhMucKhuVuc");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}