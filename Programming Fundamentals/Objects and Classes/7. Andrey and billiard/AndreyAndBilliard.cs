using System;
using System.Collections.Generic;
using System.Linq;

//public class Customer
//{
//    public string Name { get; set; }
//    public Dictionary<string, int> ShopList { get; set; }
//    public decimal Bill { get; set; }
//}

namespace _7.Andrey_and_billiard
{
    public class AndreyAndBilliard
    {
        public static void Main()
        {
            var shop = new Dictionary<string, decimal>();
            var CustomersList = new List<Customer>();

            var number = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();
            while (input.ToLower() != "end of clients")
            {
                string[] tokens = input.Split(new char[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 2) //shop section
                {
                    var productName = tokens[0];
                    var price = decimal.Parse(tokens[1]);

                    if (!shop.ContainsKey(productName))
                    {
                        shop.Add(productName, price);
                    }
                    shop[productName] = price;
                }
                else //orders section
                {
                    var qustomerName = tokens[0];
                    var itemOrdered = tokens[1];
                    var itemQuantity = int.Parse(tokens[2]);

                    if (shop.ContainsKey(itemOrdered))
                    {
                        if (CustomersList.Count(x => x.Name == qustomerName) == 0) //Customer does nto exist. Create one.
                        {
                            var currentCustomer = new Customer
                            {
                                Name = qustomerName,
                                ShopList = new Dictionary<string, int>()
                            };
                            CustomersList.Add(currentCustomer);
                        }


                        foreach (var customer in CustomersList)
                        {
                            if (customer.Name == qustomerName)
                            {
                                if (!customer.ShopList.ContainsKey(itemOrdered))
                                {
                                    customer.ShopList[itemOrdered] = 0;
                                }
                                customer.ShopList[itemOrdered] += itemQuantity;
                                break;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var customer in CustomersList) //fiil the bill
            {
                foreach (var shopList in customer.ShopList)
                {
                    customer.Bill += shopList.Value * shop[shopList.Key];
                }
            }

            //print
            decimal totalBill = 0;
            foreach (var customer in CustomersList.OrderBy(x => x.Name))
            {
                Console.WriteLine(customer.Name);
                foreach (var item in customer.ShopList)
                {
                    Console.WriteLine($"-- {item.Key } - {item.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:F2}");
                totalBill += customer.Bill;
            }
            Console.WriteLine($"Total bill: {totalBill:F2}");

        }
    }
}
