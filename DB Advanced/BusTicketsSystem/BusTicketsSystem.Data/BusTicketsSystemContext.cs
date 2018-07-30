namespace BusTicketsSystem.Data
{
    using BusTicketsSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class BusTicketsSystemContext : DbContext
    {
        public BusTicketsSystemContext()
        {
        }

        public BusTicketsSystemContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BusCompany> BusCompanies { get; set; }
        public DbSet<BusCompanyReview> BusCompanyReviews { get; set; }
        public DbSet<BusStation> BusStations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Trip> Trips { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusCompanyReview>(e =>
            {
                e.HasKey(x => new { x.BusCompanyId, x.ReviewId });
            });


            modelBuilder.Entity<BankAccount>(e =>
            {
                e.HasOne(x => x.Customer)
                 .WithOne(x => x.BankAccount)
                 .HasForeignKey<Customer>(x => x.BankAccountId);
            });

            modelBuilder.Entity<BusStation>(e =>
            {
                e.HasMany(x => x.TripsFrom)
                 .WithOne(x => x.OriginBusStation)
                 .HasForeignKey(x => x.OriginBusStationId)
                 .OnDelete(DeleteBehavior.Restrict);


                e.HasMany(x => x.TripsTo)
                 .WithOne(x => x.DestinationBusStation)
                 .HasForeignKey(x => x.DestinationBusStationId)
                 .OnDelete(DeleteBehavior.Restrict); ;
            });

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasMany(x => x.Reviews)
                 .WithOne(x => x.Customer)
                 .HasForeignKey(x => x.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
