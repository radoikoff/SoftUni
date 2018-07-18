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
                new CreditCard(){ Limit = 20000, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 5000, MoneyOwed = 500, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 200, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 80000, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 123, MoneyOwed = 5, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 20000, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 800000, MoneyOwed = 0, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){ Limit = 10000, MoneyOwed = 1000, ExpirationDate = DateTime.Now.AddYears(1)},
            };

            return creditCards;
        }
    }
}
