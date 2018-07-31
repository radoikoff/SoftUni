namespace ProductShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductShop.Models;
    using System;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(e => e.HasKey(x => new { x.CategoryId, x.ProductId }));

            modelBuilder.Entity<User>(e =>
            {
                e.HasMany(x => x.ProdcutsSold)
                 .WithOne(x => x.Seller)
                 .HasForeignKey(x => x.SellerId);

                e.HasMany(x => x.ProdcutsBought)
                 .WithOne(x => x.Buyer)
                 .HasForeignKey(x => x.BuyerId);

            });

        }
    }
}

