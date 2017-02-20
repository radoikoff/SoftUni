using System;

namespace _6.Sum_Big_Numbers
{
    public class SumBigNumbers
    {
        public static void Main()
        {
            string firstNum = Console.ReadLine();
            string secondNum = Console.ReadLine();

            int delta = Math.Abs(firstNum.Length - secondNum.Length);
            if (firstNum.Length > secondNum.Length)
            {
                secondNum = new string('0', delta) + secondNum;
            }
            else
            {
                firstNum = new string('0', delta) + firstNum;
            }

            char[] first = firstNum.ToCharArray();
            char[] second = secondNum.ToCharArray();
            int[] result = new int[first.Length];

            int reminder = 0;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                int temp = (first[i] - '0') + (second[i] - '0') + reminder;
                result[i] = temp % 10;
                reminder = temp / 10;
            }
            if (reminder != 0)
            {
                Console.WriteLine(reminder + string.Join(null, result).TrimStart(new char[] { '0' }));
            }
            else
            {
                Console.WriteLine(string.Join(null, result).TrimStart(new char[] { '0' }));
            }
        }
    }
}
