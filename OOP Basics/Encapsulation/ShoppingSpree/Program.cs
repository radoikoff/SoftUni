using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            var peopleInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            foreach (var personInput in peopleInput)
            {
                var tokens = personInput.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var personName = tokens[0];
                var personMoney = int.Parse(tokens[1]);
                try
                {
                    people.Add(new Person(personName, personMoney));
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                    return;
                }

            }

            foreach (var productInput in productsInput)
            {
                var tokens = productInput.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                var productName = tokens[0];
                var productPrice = int.Parse(tokens[1]);
                try
                {
                    products.Add(new Product(productName, productPrice));
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                    return;
                }


            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var personName = tokens[0];
                var productName = tokens[1];
                var person = people.FirstOrDefault(p => p.Name == personName);
                var product = products.FirstOrDefault(p => p.Name == productName);
                try
                {
                    Console.WriteLine(person.AddProduct(product));
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
                catch (NullReferenceException)
                {
                }

            }

            //result
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }


        }
    }
}
