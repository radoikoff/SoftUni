using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class BankAccountInitializer
    {
        internal static BankAccount[] GetBankAccounts()
        {
            var bankAccounts = new BankAccount[]
            {
                new BankAccount(){ Balance = 43200, SwiftCode = "ASDFG", BankName = "Bank One"},
                new BankAccount(){ Balance = 1000, SwiftCode = "QQQQQ", BankName = "Cental Bank"},
                new BankAccount(){ Balance = 43200, SwiftCode = "ASDFG", BankName = "Bank One"},
                new BankAccount(){ Balance = 43200, SwiftCode = "ASDFG", BankName = "Bank One"},
                new BankAccount(){ Balance = 43200, SwiftCode = "ASDFG", BankName = "Bank One"},
            };

            return bankAccounts;
        }
    }
}
