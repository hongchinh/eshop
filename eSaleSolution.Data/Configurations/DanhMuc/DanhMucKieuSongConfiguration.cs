using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class DanhMucKieuSongConfiguration : IEntityTypeConfiguration<DanhMucKieuSong>
    {
        public void Configure(EntityTypeBuilder<DanhMucKieuSong> builder)
        {
            builder.ToTable("DanhMucKieuSong");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}