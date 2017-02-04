using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ').ToList();
            List<int> numbers = new List<int>();

            foreach (var item in input)
            {
                numbers.Add(int.Parse(item));
            }

            long maxCount = 0;
            long maxNumber = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                int currentCount = 1;
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (currentNumber == numbers[j])
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
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(maxNumber + " ");
            }
        }
    }
}
