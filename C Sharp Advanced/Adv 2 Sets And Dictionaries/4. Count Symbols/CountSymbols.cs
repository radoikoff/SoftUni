using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Count_Symbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var result = new SortedDictionary<char, int>();

            foreach (char letter in input)
            {
                if (!result.ContainsKey(letter))
                {
                    result.Add(letter, 0);
                }

                result[letter]++;
            }

            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
