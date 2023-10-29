using JwtAppWebApı.Core.Domain;
using JwtAppWebApı.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAppWebApı.Persistance.Context
{
    public class JwtAndCQRSAppContext : DbContext
    {
        public JwtAndCQRSAppContext(DbContextOptions<JwtAndCQRSAppContext> options) : base(options)
        {
        }
        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                builder.HasKey(p => p.Id);
               
                builder.HasOne(p => p.Category)
                       .WithMany(c => c.Products)
                       .HasForeignKey(p => p.CategoryId);
            }
        }

        public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
        {
            public void Configure(EntityTypeBuilder<AppUser> builder)
            {
                builder.HasKey(u => u.Id);
           
                builder.HasOne(u => u.AppRole)
                       .WithMany(r => r.AppUsers)
                       .HasForeignKey(u => u.AppRoleId);
            }
        }
    }
}