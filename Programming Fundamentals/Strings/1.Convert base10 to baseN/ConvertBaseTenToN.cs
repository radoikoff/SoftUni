using System;
using System.Collections.Generic;
using System.Numerics;

namespace _1.Convert_base10_to_baseN
{
    public class ConvertBaseTenToN
    {
        public static void Main()
        {
            var result = new List<int>();
            string[] tokens = Console.ReadLine().Split();
            int baseN = int.Parse(tokens[0]);
            BigInteger number = BigInteger.Parse(tokens[1]);

            while (number > 0)
            {
                result.Add((int)(number % baseN));
                number /= baseN;
            }
            result.Reverse();
            Console.WriteLine(string.Join(null, result));
        }
    }
}
