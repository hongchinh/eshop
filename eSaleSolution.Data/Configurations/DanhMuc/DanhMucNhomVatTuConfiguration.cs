using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucNhomVatTuConfiguration : IEntityTypeConfiguration<DanhMucNhomVatTu>
    {
        public void Configure(EntityTypeBuilder<DanhMucNhomVatTu> builder)
        {
            builder.ToTable("DanhMucNhomVatTu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}