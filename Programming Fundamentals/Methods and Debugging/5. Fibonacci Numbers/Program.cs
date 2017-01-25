using System;

namespace _5.Fibonacci_Numbers
{
    class Program
    {
        static void Main()
        {
            long number = long.Parse(Console.ReadLine());
            Console.WriteLine(Fib(number));
        }

        public static long Fib(long number)
        {
            long f0 = 1;
            long f1 = 1;
            for (long i = 0; i < number - 1; i++)
            {
                long fNext = f0 + f1;
                f0 = f1;
                f1 = fNext;
            }
            return f1;
        }
    }
}
