using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main()
        {
            var names = new List<string>(Console.ReadLine().Split());
            var filters = new List<string>();

            string input = "";
            while ((input = Console.ReadLine()) != "Print")
            {
                var tokens = input.Split(';');
                var command = tokens[0];
                var filterType = tokens[1];
                var filterParam = tokens[2];

                switch (command)
                {
                    case "Add filter":
                        filters.Add(filterType + ";" + filterParam);
                        break;
                    case "Remove filter":
                        filters.Remove(filterType + ";" + filterParam);
                        break;
                }

            }

            foreach (var filter in filters)
            {
                var filterData = filter.Split(';');
                switch (filterData[0])
                {
                    case "Starts with":
                        names = names.Where(n => !n.StartsWith(filterData[1])).ToList();
                        break;

                    case "Ends with":
                        names = names.Where(n => !n.EndsWith(filterData[1])).ToList();
                        break;

                    case "Length":
                        names = names.Where(n => n.Length != int.Parse(filterData[1])).ToList();
                        break;

                    case "Contains":
                        names = names.Where(n => !n.Contains(filterData[1])).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", names));

        }
    }
}
