namespace Company.Data
{
    using Company.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.HasOne(x => x.Manager)
                 .WithMany(x => x.ManagerEmployees)
                 .HasForeignKey(x => x.ManagerId);
            });
        }


    }
}
