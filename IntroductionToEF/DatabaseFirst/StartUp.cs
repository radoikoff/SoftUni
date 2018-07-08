using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.IO;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var address = new Address()
                {
                    AddressText = "Vitoshka 15",
                    TownId = 4
                };

                context.Addresses.Add(address);

                var user = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                user.Address = address;

                context.SaveChanges();

                var emploees = context.Employees
                    .OrderByDescending(e=>e.AddressId)
                    .Take(10)                    
                    .Select(e=>e.Address.AddressText)
                    .ToList();

                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var e in emploees)
                    {
                        sw.WriteLine(e);
                    }
                }


            }


        }
    }
}
