using System;
using System.Numerics;

namespace _14.Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main()
        {
            int inputNum = int.Parse(Console.ReadLine());
            var factorialResult = Factorial(inputNum);
            Console.WriteLine(TrailingZeroes(factorialResult));
        }

        public static BigInteger Factorial(int number)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        public static int TrailingZeroes(BigInteger number)
        {
            int lastDigit = 0;
            int count = 0;
            while (number != 0)
            {
                lastDigit = (int)(number % 10);
                if (lastDigit == 0)
                {
                    count++;
                    number /= 10;
                }
                else
                {
                    break;
                }  
            }
            return count;
        }
    }
}
