using BusTicketsSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusTicketsSystem.Initializer
{
    public class CompaniesInitializer
    {
        public static BusCompany[] GetCompanies()
        {
            var companies = new BusCompany[]
            {
                new BusCompany(){ Name = "World Travel", Nationality = "USA", Rating = 3},
                new BusCompany(){ Name = "Sofia Mega Travel", Nationality = "Bulgaria", Rating = 5},
            };

            return companies;
        }
    }
}
