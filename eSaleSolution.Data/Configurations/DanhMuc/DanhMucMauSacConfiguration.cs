using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucMauSacConfiguration : IEntityTypeConfiguration<DanhMucMauSac>
    {
        public void Configure(EntityTypeBuilder<DanhMucMauSac> builder)
        {
            builder.ToTable("DanhMucMauSac");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}