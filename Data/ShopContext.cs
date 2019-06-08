using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shop.Models;

namespace shop.Data
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<TempTrans> TempTrans { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesDetail> SalesDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Term> Terms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
                .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
                .HasMaxLength(255));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
                .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
                .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
                .HasMaxLength(255));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
                .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
                .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
                .HasMaxLength(255));
        }
    }
}