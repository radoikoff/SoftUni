using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class BankAccountInitializer
    {
        internal static BankAccount[] GetBankAccounts()
        {
            var bankAccounts = new BankAccount[]
            {
                new BankAccount(){ SwiftCode = "ASDFG", BankName = "Bank One"},
                new BankAccount(){ SwiftCode = "QQQQQ", BankName = "Cental Bank"},
                new BankAccount(){ SwiftCode = "ASDFG", BankName = "Bank One"},
                new BankAccount(){ SwiftCode = "ASDFG", BankName = "Bank One"},
                new BankAccount(){ SwiftCode = "ASDFG", BankName = "Bank One"},
            };

            bankAccounts[0].Deposit(43200);
            bankAccounts[1].Deposit(1000);
            bankAccounts[2].Deposit(150);
            bankAccounts[3].Deposit(4300);
            bankAccounts[4].Deposit(876);

            return bankAccounts;
        }
    }
}
