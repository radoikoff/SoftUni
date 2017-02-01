using System;
using System.Linq;

namespace _11.Equal_Sums
{
    class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int index = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (RightSum(numbers, i) == LeftSum(numbers, i))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public static long LeftSum(int[] numbers, int index)
        {
            long sum = 0;
            for (int i = 0; i < index; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public static long RightSum(int[] numbers, int index)
        {
            long sum = 0;
            for (int i = index + 1; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
    }
}
