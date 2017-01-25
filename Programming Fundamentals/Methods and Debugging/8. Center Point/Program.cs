using System;

namespace _8.Center_Point
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            ClosestPointToCenter(x1, y1, x2, y2);
        }

        public static void ClosestPointToCenter(double x1, double y1, double x2, double y2)
        {

            double distancePoint1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double distancePoint2 = Math.Sqrt(x2 * x2 + y2 * y2);
            if (distancePoint1 <= distancePoint2)
            {
                Console.WriteLine("({0}, {1})", x1, y1);
            }
            else
            {
                Console.WriteLine("({0}, {1})", x2, y2);
            }
        }

    }
}
