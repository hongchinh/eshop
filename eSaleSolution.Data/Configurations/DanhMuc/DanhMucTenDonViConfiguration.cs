using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucTenDonViConfiguration : IEntityTypeConfiguration<DanhMucTenDonVi>
    {
        public void Configure(EntityTypeBuilder<DanhMucTenDonVi> builder)
        {
            builder.ToTable("DanhMucTenDonVi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}