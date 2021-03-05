using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucKhoVatTuConfiguration : IEntityTypeConfiguration<DanhMucKhoVatTu>
    {
        public void Configure(EntityTypeBuilder<DanhMucKhoVatTu> builder)
        {
            builder.ToTable("DanhMucKhoVatTu");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}