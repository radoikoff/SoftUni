using System;
using System.Numerics;

namespace _2.Convert_baseN_to_base10
{
    public class ConvertNtoTen
    {
        public static void Main()
        {
            string[] tokens = Console.ReadLine().Split();
            int baseN = int.Parse(tokens[0]);
            char[] number = tokens[1].ToCharArray();
            BigInteger pow = 1;
            BigInteger sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum += (number[number.Length - 1 - i] - '0') * pow;
                pow *= baseN;
            }
            Console.WriteLine(sum);
        }

    }
}
