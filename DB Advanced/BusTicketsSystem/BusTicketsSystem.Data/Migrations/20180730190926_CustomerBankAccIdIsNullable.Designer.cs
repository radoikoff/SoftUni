﻿// <auto-generated />
using System;
using BusTicketsSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BusTicketsSystem.Data.Migrations
{
    [DbContext(typeof(BusTicketsSystemContext))]
    [Migration("20180730190926_CustomerBankAccIdIsNullable")]
    partial class CustomerBankAccIdIsNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusTicketsSystem.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .IsRequired();

                    b.Property<decimal>("Balance");

                    b.Property<int>("CustomerId");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.BusCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Nationality");

                    b.Property<int>("Rating");

                    b.HasKey("Id");

                    b.ToTable("BusCompanies");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.BusCompanyReview", b =>
                {
                    b.Property<int>("BusCompanyId");

                    b.Property<int>("ReviewId");

                    b.HasKey("BusCompanyId", "ReviewId");

                    b.HasIndex("ReviewId");

                    b.ToTable("BusCompanyReviews");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.BusStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("BusStations");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankAccountId");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId")
                        .IsUnique()
                        .HasFilter("[BankAccountId] IS NOT NULL");

                    b.HasIndex("TownId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusStationId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<int>("CustomerId");

                    b.Property<double>("Grade");

                    b.Property<DateTime>("PublishedDate");

                    b.HasKey("Id");

                    b.HasIndex("BusStationId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<decimal>("Price");

                    b.Property<string>("Seat");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Town", b =>
                {
                    b.Property<int>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("TownId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime");

                    b.Property<int>("BusCompanyId");

                    b.Property<DateTime>("DepartureTime");

                    b.Property<int>("DestinationBusStationId");

                    b.Property<int>("OriginBusStationId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BusCompanyId");

                    b.HasIndex("DestinationBusStationId");

                    b.HasIndex("OriginBusStationId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("BusTicketsSystem.Models.BusCompanyReview", b =>
                {
                    b.HasOne("BusTicketsSystem.Models.BusCompany", "BusCompany")
                        .WithMany("BusCompanyReviews")
                        .HasForeignKey("BusCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusTicketsSystem.Models.Review", "Review")
                        .WithMany("BusCompanyReviews")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusTicketsSystem.Models.BusStation", b =>
                {
                    b.HasOne("BusTicketsSystem.Models.Town", "Town")
                        .WithMany("BusStations")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Customer", b =>
                {
                    b.HasOne("BusTicketsSystem.Models.BankAccount", "BankAccount")
                        .WithOne("Customer")
                        .HasForeignKey("BusTicketsSystem.Models.Customer", "BankAccountId");

                    b.HasOne("BusTicketsSystem.Models.Town", "HomeTown")
                        .WithMany("Customers")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Review", b =>
                {
                    b.HasOne("BusTicketsSystem.Models.BusStation", "BusStation")
                        .WithMany("Reviews")
                        .HasForeignKey("BusStationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusTicketsSystem.Models.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Ticket", b =>
                {
                    b.HasOne("BusTicketsSystem.Models.Customer", "Customer")
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusTicketsSystem.Models.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BusTicketsSystem.Models.Trip", b =>
                {
                    b.HasOne("BusTicketsSystem.Models.BusCompany", "BusCompany")
                        .WithMany("Trips")
                        .HasForeignKey("BusCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BusTicketsSystem.Models.BusStation", "DestinationBusStation")
                        .WithMany("TripsTo")
                        .HasForeignKey("DestinationBusStationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BusTicketsSystem.Models.BusStation", "OriginBusStation")
                        .WithMany("TripsFrom")
                        .HasForeignKey("OriginBusStationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
