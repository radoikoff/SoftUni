using System;
using System.Linq;


namespace _5.Compare_Char_Arrays
{
    class Program
    {
        static void Main()
        {
            var firstInput = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            var secondInput = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            int minCount = Math.Min(firstInput.Length, secondInput.Length);
            int first = 0;

            for (int i = 0; i < minCount; i++)
            {
                if (firstInput[i] < secondInput[i])
                {
                    first = 1;
                    break;
                }
                else if (firstInput[i] > secondInput[i])
                {
                    first = 2;
                    break;
                }
            }

            switch (first)
            {
                case 0:
                    if (firstInput.Length < secondInput.Length)
                    {
                        printResult(firstInput, secondInput);
                    }
                    else
                    {
                        printResult(secondInput, firstInput );
                    }
                    break;
                case 1:
                    printResult(firstInput, secondInput);
                    break;
                case 2:
                    printResult(secondInput, firstInput);
                    break;
            }


        }
        public static void printResult(char[] first, char[] second)
        {
            foreach (var item in first)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            foreach (var item in second)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
