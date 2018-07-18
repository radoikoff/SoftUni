using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class UserInitializer
    {
        internal static User[] GetUsers()
        {
            User[] users = new User[]
            {
                new User() { FirstName = "Gosho", LastName = "Goshev", Email = "Gosho.Goshev@gmail.com", Password = "12345"},
                new User() { FirstName = "Pesho", LastName = "Peshov", Email = "Pesho.Peshov@gmail.com", Password = "qwerty"},
                new User() { FirstName = "Ivan", LastName = "Ivanov", Email = "Ivan.Ivanov@gmail.com", Password = "ura"},
                new User() { FirstName = "Stamat", LastName = "Ignatov", Email = "stami@abv.bg", Password = "asdf1"},
                new User() { FirstName = "Hristo", LastName = "Hristov", Email = "hhristov22@yahoo.com", Password = "888888"}
            };

            return users;
        }
    }
}
