using System;

namespace _4.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main()
        {
            string number = Console.ReadLine();
            PrintNumberInRevOrder(number);
        }

        public static void PrintNumberInRevOrder (string number)
        {
            for (int i = number.Length-1; i >=0; i--)
            {
                Console.Write(number[i]);
            }
        }
    }
}
