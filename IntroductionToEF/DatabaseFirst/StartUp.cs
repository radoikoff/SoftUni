using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.IO;
using P02_DatabaseFirst.Data.Models;
using System.Globalization;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {

                var adresses = context.Addresses
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Select(a => new
                    {
                        AddressText = a.AddressText,
                        TownName = a.Town.Name,
                        Count = a.Employees.Count
                    })
                    .Take(10)
                    .ToArray();


                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var e in adresses)
                    {
                        sw.WriteLine($"{e.AddressText}, {e.TownName} - {e.Count} employees");

                       
                    }
                }
            }
        }

    }
}






