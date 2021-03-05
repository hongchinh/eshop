using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucLyDoThuChiConfiguration : IEntityTypeConfiguration<DanhMucLyDoThuChi>
    {
        public void Configure(EntityTypeBuilder<DanhMucLyDoThuChi> builder)
        {
            builder.ToTable("DanhMucLyDoThuChi");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}