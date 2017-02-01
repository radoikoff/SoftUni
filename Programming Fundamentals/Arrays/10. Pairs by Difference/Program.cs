using System;
using System.Linq;


namespace _10.Pairs_by_Difference
{
    class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int diff = int.Parse(Console.ReadLine());


            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (Math.Abs(currentNumber - numbers[j]) == diff)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
