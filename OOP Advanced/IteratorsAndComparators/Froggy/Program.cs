using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main()
        {
            int[] stones = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
