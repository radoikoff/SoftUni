using System;
using System.Linq;

namespace _8.Most_Frequent_Number
{
    public class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            long maxCount = 0;
            long maxNumber = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int currentNumber = input[i];
                int currentCount = 1;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (currentNumber == input[j])
                    {
                        currentCount++;
                    }
                }
                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxNumber = currentNumber;
                }
            }
            Console.WriteLine(maxNumber);

        }
    }
}
