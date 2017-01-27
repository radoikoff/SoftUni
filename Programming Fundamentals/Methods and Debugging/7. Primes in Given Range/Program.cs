using System;
using System.Collections.Generic;

namespace _7.Primes_in_Given_Range
{
    class Program
    {
        static void Main()
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            var primesInRange = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(string.Join(", ", primesInRange));
        }

        public static List<int> FindPrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int currentNum = start; currentNum <= end; currentNum++)
            {
                if (IsPrime(currentNum))
                {
                    primes.Add(currentNum);
                }
            }
            return primes;
        }

        public static bool IsPrime(long number)
        {
            bool prime = true;
            if (number < 2)
            {
                prime = false;
            }

            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }
    }
}

