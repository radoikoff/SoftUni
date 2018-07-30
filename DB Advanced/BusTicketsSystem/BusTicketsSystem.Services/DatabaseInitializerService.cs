namespace BusTicketsSystem.Services.Contracts
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using BusTicketsSystem.Initializer;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.Linq;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly BusTicketsSystemContext context;

        public DatabaseInitializerService(BusTicketsSystemContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }

        public void Seed()
        {
            InsertTowns();
            InsertBusStations();
            InsertCompanies();
            InsertTrips();
            InsertCustomers();
            InsertBankAccounts();
            SetCustomersAccounts();
        }


        private void InsertTowns()
        {
            var towns = TownsInitializer.GetTowns();

            for (int i = 0; i < towns.Length; i++)
            {
                if (IsValid(towns[i]))
                {
                    this.context.Towns.Add(towns[i]);
                }
            }

            context.SaveChanges();
        }

        private void InsertBusStations()
        {
            var stations = BusStationsInitializer.GetBusStations();

            for (int i = 0; i < stations.Length; i++)
            {
                if (IsValid(stations[i]))
                {
                    this.context.BusStations.Add(stations[i]);
                }
            }

            context.SaveChanges();
        }

        private void InsertCompanies()
        {
            var companies = CompaniesInitializer.GetCompanies();

            for (int i = 0; i < companies.Length; i++)
            {
                if (IsValid(companies[i]))
                {
                    this.context.BusCompanies.Add(companies[i]);
                }
            }

            context.SaveChanges();
        }

        private void InsertTrips()
        {
            var trips = TripInitializer.GetTrips();

            for (int i = 0; i < trips.Length; i++)
            {
                if (IsValid(trips[i]))
                {
                    this.context.Trips.Add(trips[i]);
                }
            }

            context.SaveChanges();
        }

        private void InsertBankAccounts()
        {
            var accounts = BankAccountInitializer.GetBankAccounts();

            for (int i = 0; i < accounts.Length; i++)
            {
                if (IsValid(accounts[i]))
                {
                    this.context.BankAccounts.Add(accounts[i]);
                }
            }

            context.SaveChanges();
        }

        private void InsertCustomers()
        {
            var customers = CustomerInitializer.GetCustomers();

            for (int i = 0; i < customers.Length; i++)
            {
                if (IsValid(customers[i]))
                {
                    this.context.Customers.Add(customers[i]);
                }
            }

            context.SaveChanges();
        }

        public void SetCustomersAccounts()
        {
            this.context.Customers.Where(x => x.FirstName == "Pesho").FirstOrDefault().BankAccountId = 1;
            this.context.Customers.Where(x => x.FirstName == "Camelia").FirstOrDefault().BankAccountId = 2;
            this.context.SaveChanges();
        }

        private bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var results = new List<ValidationResult>();
            return Validator.TryValidateObject(obj, validationContext, results, true);
        }

    }
}
