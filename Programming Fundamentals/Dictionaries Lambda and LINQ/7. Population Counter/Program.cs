using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Population_Counter
{
    class Program
    {
        public static void Main()
        {
            var populationData = new Dictionary<string, Dictionary<string, long>>();
            var line = Console.ReadLine();

            while (line != "report")
            {
                var tokens = line.Split('|');
                string city = tokens[0];
                string country = tokens[1];
                long cityPopulation = long.Parse(tokens[2]);

                if (!populationData.ContainsKey(country))
                {
                    populationData[country] = new Dictionary<string, long>();
                }
                populationData[country].Add(city, cityPopulation);
                line = Console.ReadLine();
            }
            foreach (var country in populationData.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            //foreach (var country in populationData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                var cityCount = country.Value;
                Console.WriteLine($"{country.Key} (total population: {cityCount.Values.Sum()})");
                foreach (var city in cityCount.OrderByDescending(a => a.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
