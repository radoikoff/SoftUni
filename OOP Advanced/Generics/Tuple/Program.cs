using System;

namespace Tuple
{
    class Program
    {

        public static void Main()
        {
            var args = Console.ReadLine().Split();
            var fullName = args[0] + " " + args[1];
            var firstTuple = new Threeuple<string, string, string>(fullName, args[2], args[3]);
            Console.WriteLine(firstTuple.ToString());

            args = Console.ReadLine().Split();
            bool isDrunk = args[2] == "drunk";

            var secondTuple = new Threeuple<string, int, bool>(args[0], int.Parse(args[1]), isDrunk);
            Console.WriteLine(secondTuple.ToString());

            args = Console.ReadLine().Split();
            var thirdTuple = new Threeuple<string, double, string>(args[0], double.Parse(args[1]), args[2]);
            Console.WriteLine(thirdTuple.ToString());

        }

    }
}
