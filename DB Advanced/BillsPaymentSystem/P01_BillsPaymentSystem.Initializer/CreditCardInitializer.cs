using P01_BillsPaymentSystem.Data.Models;
using System;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class CreditCardInitializer
    {
        internal static CreditCard[] GetCreditCards()
        {
            CreditCard[] creditCards = new CreditCard[]
            {
                new CreditCard(){ Limit = 20000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 5000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 200, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 80000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 123, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 20000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 800000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 10000, ExpirationDate = DateTime.Now.AddYears(1)},
            };

            creditCards[0].Deposit(500);
            creditCards[1].Deposit(20);
            creditCards[2].Deposit(10000);
            creditCards[3].Deposit(25000);
            creditCards[4].Deposit(654);
            creditCards[5].Deposit(2300);
            creditCards[6].Deposit(500);
            creditCards[7].Deposit(1);

            return creditCards;
        }
    }
}
