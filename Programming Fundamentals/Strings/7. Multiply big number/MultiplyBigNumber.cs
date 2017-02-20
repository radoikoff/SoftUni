using System;

namespace _7.Multiply_big_number
{
    public class MultiplyBigNumber
    {
        public static void Main()
        {
            string firstNum = Console.ReadLine().TrimStart(new char[] { '0' });
            int secondNum = int.Parse(Console.ReadLine());

            if (firstNum == "0" || firstNum == "" || secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            char[] first = firstNum.ToCharArray();
            int[] result = new int[first.Length];

            int reminder = 0;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                int temp = (first[i] - '0') * secondNum + reminder;
                result[i] = temp % 10;
                reminder = temp / 10;
            }

            if (reminder != 0)
            {
                Console.WriteLine(reminder + string.Join(null,result));
            }
            else
            {
                Console.WriteLine(string.Join(null, result));
            }
        }
    }
}
