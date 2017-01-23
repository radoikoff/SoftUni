using System;
using System.Numerics;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main()
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            string result = "";
            if (input >= sbyte.MinValue && input <= sbyte.MaxValue)
            {
                result += "* sbyte\n";
            }
            if (input >= byte.MinValue && input <= byte.MaxValue)
            {
                result += "* byte\n";
            }
            if (input >= short.MinValue && input <= short.MaxValue)
            {
                result += "* short\n";
            }
            if (input >= ushort.MinValue && input <= ushort.MaxValue)
            {
                result += "* ushort\n";
            }
            if (input >= int.MinValue && input <= int.MaxValue)
            {
                result += "* int\n";
            }
            if (input >= uint.MinValue && input <= uint.MaxValue)
            {
                result += "* uint\n";
            }
            if (input >= long.MinValue && input <= long.MaxValue)
            {
                result += "* long\n";
            }
            if (result != "")
            {
                Console.WriteLine($"{input} can fit in:\n{result}");
            }
            else
            {
                Console.WriteLine($"{input} can't fit in any type");
            }

        }
    }
}
