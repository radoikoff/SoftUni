using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Sum_Reversed_Numbers
{
    public static class Program
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine().Split(' ').ToList();
            List<int> invertedNumbers = new List<int>();

            foreach (var number in numbers)
            {
                invertedNumbers.Add(InversedNumber(number));
            }
            Console.WriteLine(invertedNumbers.Sum());
            //Console.WriteLine(string.Join(" ",invertedNumbers));
        }

        public static int InversedNumber(string inputNum)
        {
            string resultNum = "";
            for (int i = inputNum.Length -1; i >= 0; i--)
            {
                resultNum += inputNum[i];
            }
            return int.Parse(resultNum);
        }
    }
}
