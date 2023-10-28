using JwtAppWebApı.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JwtAppWebApı.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne<AppRole>().WithMany(x=>x.AppUsers).HasForeignKey(x=>x.AppRoleId);
        }
    }

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne<Category>().WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }

}
