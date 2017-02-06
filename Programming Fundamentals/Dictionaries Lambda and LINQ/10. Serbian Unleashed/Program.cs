using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Serbian_Unleashed
{
    public class Program
    {
        public static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, long>>();

            var input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                var tokens = input.Split(' ').ToList();
                if (tokens.Count < 4)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string singerName = string.Empty;
                string venue = string.Empty;
                int ticketsPrice = 0;
                long ticketsCount = 0;

                bool a = long.TryParse(tokens.Last(), out ticketsCount);
                tokens.RemoveAt(tokens.Count - 1);
                bool b = int.TryParse(tokens.Last(), out ticketsPrice);
                tokens.RemoveAt(tokens.Count - 1);
                if (!a || !b)
                {
                    input = Console.ReadLine();
                    continue;
                }
                var venueIndex = tokens.FindIndex(x => x.StartsWith("@"));
                if (venueIndex < 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                var venueAsList = tokens.Skip(venueIndex).ToList();
                venue = string.Join(" ", venueAsList).Remove(0, 1);
                tokens.RemoveRange(venueIndex, tokens.Count - venueIndex);
                singerName = string.Join(" ", tokens);

                //Add data
                if (!data.ContainsKey(venue))
                {
                    data[venue] = new Dictionary<string, long>();
                }
                if (!data[venue].ContainsKey(singerName))
                {
                    data[venue].Add(singerName, 0);
                }
                data[venue][singerName] += ticketsCount * ticketsPrice;

                input = Console.ReadLine();
            }

            foreach (var venue in data)
            {
                Console.WriteLine($"{venue.Key}");
                foreach (var singer in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}