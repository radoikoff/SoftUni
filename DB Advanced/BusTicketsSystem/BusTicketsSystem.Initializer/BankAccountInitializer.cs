namespace BusTicketsSystem.Initializer
{
    using BusTicketsSystem.Models;

    public class BankAccountInitializer
    {
        public static BankAccount[] GetBankAccounts()
        {
            var bankAccounts = new BankAccount[]
            {
                new BankAccount(){ AccountNumber = "BG_233R3453", Balance = 120.50m, CustomerId = 1},
                new BankAccount(){ AccountNumber = "AU_13131234", Balance = 5000.00m, CustomerId = 2 }
            };

            return bankAccounts;
        }
    }
}
