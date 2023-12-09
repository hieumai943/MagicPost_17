
using MagicPost__Data.Configurations;
using MagicPost__Data.Entities;

using MagicPost_Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace MagicPost__Data.EF
{
    public class MagicPostDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public MagicPostDbContext(DbContextOptions options) : base(options) { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
			modelBuilder.ApplyConfiguration(new AppUserConfiguration());
			modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
			modelBuilder.ApplyConfiguration(new ContactConfiguration());
			modelBuilder.ApplyConfiguration(new LanguageConfiguration());

			modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new OrderImageConfiguration());
			modelBuilder.ApplyConfiguration(new SlideConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new DiemGiaoDichConfiguration());
            modelBuilder.ApplyConfiguration(new DiemTapKetConfiguration());


            // identity configuration 


            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
            // data seeding
            modelBuilder.Seed();

            /* base.OnModelCreating(modelBuilder);*/
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderTranslation> ProductTranslations { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<OrderImage> ProductImages { get; set; }

        public DbSet<Slide> Slides { get; set; }
        public DbSet<DiemGiaoDich> DiemGiaoDichs { get; set; }
        public DbSet<DiemTapKet> DiemTapKets { get; set; }

    }
}
