namespace E_Store.Data.Data
{
    using System.Linq;
    
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
        
        public DbSet<Review> Reviews { get; set; }
        
        public DbSet<Address> Addresses { get; set; }
        
        public DbSet<Bank> Banks { get; set; }
        
        public DbSet<BankAccount> BankAccounts { get; set; }
        
        public DbSet<Country> Countries { get; set; }
        
        public DbSet<Person> People { get; set; }
        
        public DbSet<PersonDetail> PersonDetails { get; set; }

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

            builder
                .Entity<Person>()
                .HasKey(p => p.Id);

            builder
                .Entity<Person>()
                .HasOne(p => p.User)
                .WithOne(u => u.Person)
                .IsRequired(false);

            var cascadeFks = from type in builder.Model.GetEntityTypes()
                from foreignKey in type.GetForeignKeys()
                where !foreignKey.IsOwnership && foreignKey.DeleteBehavior == DeleteBehavior.Cascade
                select foreignKey;

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            base.OnModelCreating(builder);
        }
    }
    
}