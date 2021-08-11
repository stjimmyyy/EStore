namespace E_Store.Data.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    public class EStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public EStoreDbContext(DbContextOptions<EStoreDbContext> options)
            : base (options)
        {
            
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("decimal(10,1)");

            builder
                .Entity<Product>()
                .Property(x => x.OldPrice)
                .HasColumnType("decimal(10,1)");

            builder
                .Entity<CategoryProduct>()
                .HasKey(cp => new {cp.CategoryId, cp.ProductId});

            builder
                .Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<CategoryProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            
            base.OnModelCreating(builder);
        }
    }
    
}