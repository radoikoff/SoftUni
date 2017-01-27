using System;
using System.Numerics;

namespace _13.Factorial
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            BigInteger factorial = 1;
            for (int i = 1; i <= input; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
