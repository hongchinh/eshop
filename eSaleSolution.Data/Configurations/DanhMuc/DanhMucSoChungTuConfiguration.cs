using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucSoChungTuConfiguration : IEntityTypeConfiguration<DanhMucSoChungTu>
    {
        public void Configure(EntityTypeBuilder<DanhMucSoChungTu> builder)
        {
            builder.ToTable("DanhMucSoChungTu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}