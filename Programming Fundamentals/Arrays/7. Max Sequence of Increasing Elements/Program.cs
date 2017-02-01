using System;
using System.Linq;

namespace _7.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = 0;
            int len = 1;
            int bestStart = 0;
            int bestLen = 1;

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] - input[i - 1] >= 1)
                {
                    len++;
                }
                else
                {
                    start = i;
                    len = 1;
                }
                if (len > bestLen)
                {
                    bestStart = start;
                    bestLen = len;
                }
            }

            string result = "";
            for (int i = bestStart; i < bestStart + bestLen; i++)
            {
                result += input[i] + " ";
            }
            Console.WriteLine(result);
        }
    }
}
