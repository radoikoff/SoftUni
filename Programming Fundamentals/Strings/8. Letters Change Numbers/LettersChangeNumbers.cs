using System;

namespace _8.Letters_Change_Numbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ','\t' }, StringSplitOptions.RemoveEmptyEntries);
            double result = 0;
            foreach (var item in input)
            {
                result += GetNumberEquivalent(item);
            }

            Console.WriteLine($"{result:f2}");
        }

        public static double GetNumberEquivalent(string sequence)
        {
            char firstLetter = sequence[0];
            char lastLetter = sequence[sequence.Length - 1];
            double number = double.Parse(sequence.Remove(0, 1).Remove(sequence.Length - 2));

            if (firstLetter < 97) //capital letter
            {
                number /= firstLetter - 'A' + 1;
            }
            else
            {
                number *= firstLetter - 'a' + 1;
            }

            if (lastLetter < 97) //capital letter
            {
                number -= lastLetter - 'A' + 1;
            }
            else
            {
                number += lastLetter - 'a' + 1;
            }

            return number;
        }
    }
}
