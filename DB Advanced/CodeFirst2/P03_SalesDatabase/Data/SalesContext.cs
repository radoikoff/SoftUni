using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        { }

        public SalesContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(x => x.ProductId);

                e.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsRequired()
                    .IsUnicode();

                e.Property(x => x.Description)
                    .HasMaxLength(250)
                    .HasDefaultValue("No description")
                    .IsUnicode();

                e.HasMany(x => x.Sales)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(x => x.CustomerId);

                e.Property(x => x.Name)
                    .HasMaxLength(100)
                    .IsRequired()
                    .IsUnicode();

                e.Property(x => x.Email)
                    .HasMaxLength(80)
                    .IsRequired()
                    .IsUnicode(false);

                e.HasMany(x => x.Sales)
                    .WithOne(x => x.Customer)
                    .HasForeignKey(x => x.CustomerId);
            });

            modelBuilder.Entity<Store>(e =>
            {
                e.HasKey(x => x.StoreId);

                e.Property(x => x.Name)
                    .HasMaxLength(80)
                    .IsRequired()
                    .IsUnicode();

                e.HasMany(x => x.Sales)
                .WithOne(x => x.Store)
                .HasForeignKey(x => x.StoreId);
            });

            modelBuilder.Entity<Sale>(e =>
            {
                e.HasKey(x => x.SaleId);

                e.Property(x => x.Date)
                    .HasDefaultValueSql("GETDATE()");
            });


        }
    }
}
