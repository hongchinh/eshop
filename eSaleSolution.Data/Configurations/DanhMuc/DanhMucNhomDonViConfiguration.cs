using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucNhomDonViConfiguration : IEntityTypeConfiguration<DanhMucNhomDonVi>
    {
        public void Configure(EntityTypeBuilder<DanhMucNhomDonVi> builder)
        {
            builder.ToTable("DanhMucNhomDonVi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}