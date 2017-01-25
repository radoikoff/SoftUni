using System;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main()
        {
            double cubeSide = double.Parse(Console.ReadLine());
            string calcParameter = Console.ReadLine();
            Console.WriteLine("{0:f2}",Calculations(cubeSide, calcParameter));
        }

        public static double Calculations(double side, string parameter)
        {
            switch (parameter.ToLower())
            {
                case "face":
                    return Math.Sqrt(2 * side * side);
                case "space":
                    return Math.Sqrt(3 * side * side);
                case "volume":
                    return side * side * side;
                case "area":
                    return 6 * side * side;
                default:
                    return -1;
            }
        }
    }
}
