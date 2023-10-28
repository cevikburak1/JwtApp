using JwtAppWebApı.Core.Domain;
using JwtAppWebApı.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwtAppWebApı.Persistance.Context
{
    public class JwtAndCQRSAppContext:DbContext
    {
        public JwtAndCQRSAppContext(DbContextOptions<JwtAndCQRSAppContext> options) :base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
