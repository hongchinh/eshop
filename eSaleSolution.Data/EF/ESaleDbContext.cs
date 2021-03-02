using eSaleSolution.Data.Configurations;
using eSaleSolution.Data.Entities;
using eSaleSolution.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.Data.EF
{
    public class ESaleDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ESaleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CartConfiguration());

            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new SlideConfiguration());

            modelBuilder.ApplyConfiguration(new DanhMucHangHoaConfiguration());


            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //Data seeding
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<AppConfig> AppConfigs { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<ProductInCategory> ProductInCategories { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Slide> Slides { get; set; }

        public DbSet<DanhMucHangHoa> DanhMucHangHoas { get; set; }

        public DbSet<DanhMucChungLoai> DanhMucChungLoais { get; set; }

        public DbSet<DanhMucDoDay> DanhMucDoDays { get; set; }

        public DbSet<DanhMucDonViTrucThuoc> DanhMucDonViTrucThuocs { get; set; }

        public DbSet<DanhMucHinhThucTT> DanhMucHinhThucTTs { get; set; }

        public DbSet<DanhMucHopDong> DanhMucHopDongs { get; set; }

        public DbSet<DanhMucKhoanChi> DanhMucKhoanChis { get; set; }

        public DbSet<DanhMucKhoanThu> DanhMucKhoanThus { get; set; }

        public DbSet<DanhMucKhoVatTu> DanhMucKhoVatTus { get; set; }

        public DbSet<DanhMucKhuVuc> DanhMucKhuVucs { get; set; }

        public DbSet<DanhMucKieuSong> DanhMucKieuSongs { get; set; }

        public DbSet<DanhMucLoaiNhapXuat> DanhMucLoaiNhapXuats { get; set; }

        public DbSet<DanhMucLoaiTien> DanhMucLoaiTiens { get; set; }

        public DbSet<DanhMucLoaiTon> DanhMucLoaiTons { get; set; }

        public DbSet<DanhMucLyDoNhapXuat> DanhMucLyDoNhapXuats { get; set; }
        
        public DbSet<DanhMucLyDoThuChi> DanhMucLyDoThuChis { get; set; }
        
        public DbSet<DanhMucMauSac> DanhMucMauSacs { get; set; }
        
        public DbSet<DanhMucNhomDonVi> DanhMucNhomDonVis { get; set; }
        
        public DbSet<DanhMucNhomDonViCap2> DanhMucNhomDonViCap2s { get; set; }
        
        public DbSet<DanhMucNhomVatTu> DanhMucNhomVatTus { get; set; }
        
        public DbSet<DanhMucNhomVatTuCap2> DanhMucNhomVatTuCap2s { get; set; }
        
        public DbSet<DanhMucSoChungTu> DanhMucSoChungTus { get; set; }
        
        public DbSet<DanhMucTenDonVi> DanhMucTenDonVis { get; set; }



    }
}