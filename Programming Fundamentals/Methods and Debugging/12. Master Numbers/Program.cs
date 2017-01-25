using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Master_Numbers
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                if (SumOfDigits(i) && ContainsEvenDigit(i) && IsPalindrome(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        public static bool SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            if (sum % 7 == 0)
            {
                return true; //zero will return true
            }
            else
            {
                return false;
            }
        }
        public static bool ContainsEvenDigit(int number)
        {
            int lastDigit = 0;
            bool isEven = false;
            while (number != 0)
            {
                lastDigit = number % 10;
                if (lastDigit % 2 == 0)
                {
                    isEven = true;
                    break;
                }
                number /= 10;
            }
            return isEven; //zero will return false
        }
        public static bool IsPalindrome(int number)
        {
            string sNumber = number.ToString();
            int j = sNumber.Length - 1;
            for (int i = 0; i < sNumber.Length; i++, j--)
            {
                if (sNumber[i] != sNumber[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
