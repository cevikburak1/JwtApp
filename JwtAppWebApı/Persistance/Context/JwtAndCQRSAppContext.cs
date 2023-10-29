using JwtAppWebApı.Core.Domain;
using JwtAppWebApı.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwtAppWebApı.Persistance.Context
{
    public class JwtAndCQRSAppContext : DbContext
    {
        public JwtAndCQRSAppContext(DbContextOptions<JwtAndCQRSAppContext> options) : base(options)
        {
        }
        public DbSet<Product>Products =>this.Set<Product>();
        public DbSet<Category> Categories =>this.Set<Category>();
        public DbSet<AppUser> AppUsers =>this.Set<AppUser>();
        public DbSet<AppRole> AppRoles =>this.Set<AppRole>();  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
