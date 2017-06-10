using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Recursive_Fibonacci
{
    public class RecursiveFibonacci
    {
        public static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var lookupTable = new Dictionary<int, double>();

            double result = GetFibonnacci(input, lookupTable);

            Console.WriteLine(result);
        }

        private static double GetFibonnacci(int input, Dictionary<int, double> lookupTable)
        {
            if (input == 1 || input == 2)
            {
                return 1;
            }
            else if (lookupTable.ContainsKey(input))
            {
                return lookupTable[input];
            }
            else
            {
                var fibResult = GetFibonnacci(input - 1, lookupTable) + GetFibonnacci(input - 2, lookupTable);
                lookupTable.Add(input, fibResult);
                return fibResult;
            }
        }
    }
}
