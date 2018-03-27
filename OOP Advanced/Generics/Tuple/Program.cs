using System;

namespace Tuple
{
    class Program
    {

        public static void Main()
        {
            var args = Console.ReadLine().Split();
            var fullName = args[0] + ' ' + args[1];
            var firstTuple = new Tuple<string, string>(fullName, args[2]);
            Console.WriteLine($"{firstTuple.FirstItem} -> {firstTuple.SecondItem}");

            args = Console.ReadLine().Split();
            var secondTuple = new Tuple<string, int>(args[0], int.Parse(args[1]));
            Console.WriteLine($"{secondTuple.FirstItem} -> {secondTuple.SecondItem}");

            args = Console.ReadLine().Split();
            var thirdTuple = new Tuple<int, double>(int.Parse(args[0]), double.Parse(args[1]));
            Console.WriteLine($"{thirdTuple.FirstItem} -> {thirdTuple.SecondItem}");

        }

    }
}
