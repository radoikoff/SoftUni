using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Fast_Prime_Checker___Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            for (int currentNumber = 2; currentNumber <= inputNumber; currentNumber++)
            {
                bool isPrime = true;
                for (int counter = 2; counter <= Math.Sqrt(currentNumber); counter++)
                {
                    if (currentNumber % counter == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }

        }
    }
}
