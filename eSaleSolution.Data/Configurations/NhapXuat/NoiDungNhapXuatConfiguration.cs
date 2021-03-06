using eSaleSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eSaleSolution.Data.Configurations
{
    public class NoiDungNhapXuatConfiguration : IEntityTypeConfiguration<NoiDungNhapXuat>
    {
        public void Configure(EntityTypeBuilder<NoiDungNhapXuat> builder)
        {
            builder.ToTable("NoiDungNhapXuat");
            
            //builder.HasKey(x => x.id);
            
            //builder.Property(x => x.id).UseIdentityColumn();
        }
        
    }
}
