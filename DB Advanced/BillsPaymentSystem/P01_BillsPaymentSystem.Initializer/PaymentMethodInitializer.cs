using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class PaymentMethodInitializer
    {
        internal static PaymentMethod[] GetPaymentMethods()
        {
            var paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod(){ UserId = 1, Type = PaymentMethodType.BankAccount, BankAccountId = 1, CreditCardId = null},
                new PaymentMethod(){ UserId = 1, Type = PaymentMethodType.CreditCard, BankAccountId = null, CreditCardId = 1},
                new PaymentMethod(){ UserId = 2, Type = PaymentMethodType.BankAccount, BankAccountId = 2, CreditCardId = null},
                new PaymentMethod(){ UserId = 3, Type = PaymentMethodType.CreditCard, BankAccountId = null, CreditCardId = 2},
                new PaymentMethod(){ UserId = 4, Type = PaymentMethodType.CreditCard, BankAccountId = null, CreditCardId = 3},
                new PaymentMethod(){ UserId = 5, Type = PaymentMethodType.CreditCard, BankAccountId = null, CreditCardId = 4},
            };

            return paymentMethods;
        }
    }
}
