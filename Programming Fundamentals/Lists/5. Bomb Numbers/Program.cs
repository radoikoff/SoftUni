using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Bomb_Numbers
{
    public static class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var bomb = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int bombNumber = bomb[0];
            int bombPower = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    for (int j = -1 * bombPower; j <= bombPower; j++)
                    {
                        if (i + j >= 0 && i + j < numbers.Count)
                        {
                            numbers.RemoveAt(i + j);
                            i--;
                        }
                    }
                    i = 0;
                }
            }
            Console.WriteLine(numbers.Sum());
            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
