namespace BusTicketsSystem.Initializer
{
    using BusTicketsSystem.Models;
    using BusTicketsSystem.Models.Enums;

    public class CustomerInitializer
    {
        public static Customer[] GetCustomers()
        {
            var customers = new Customer[]
            {
                new Customer(){  FirstName = "Pesho", LastName = "Peshov", Gender = Gender.Male, TownId = 7},
                new Customer(){  FirstName = "Camelia", LastName = "Vencislavova", Gender = Gender.Female, TownId = 8},
            };

            return customers;
        }

        
    }
}
