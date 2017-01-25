using System;

namespace _6.Prime_Checker
{
    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(number)); //.ToString().ToLower());
        }

        public static bool IsPrime (long number)
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
