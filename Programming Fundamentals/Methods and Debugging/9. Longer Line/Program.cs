using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Longer_Line
{
    class Program
    {
        static void Main()
        {
            //DOES NOT WORK
            double line1x1 = double.Parse(Console.ReadLine());
            double line1y1 = double.Parse(Console.ReadLine());
            double line1x2 = double.Parse(Console.ReadLine());
            double line1y2 = double.Parse(Console.ReadLine());
            double line2x1 = double.Parse(Console.ReadLine());
            double line2y1 = double.Parse(Console.ReadLine());
            double line2x2 = double.Parse(Console.ReadLine());
            double line2y2 = double.Parse(Console.ReadLine());

            double line1Lenght = LineLenght(line1x1, line1y1, line1x2, line1y2);
            double line2Lenght = LineLenght(line2x1, line2y1, line2x2, line2y2);

            if (line1Lenght >= line2Lenght)
            {
                if (isPointOneClosestToCenter(line1x1, line1y1, line1x2, line1y2))
                {
                    Console.WriteLine($"({line1x1}, {line1y1})({line1x2}, {line1y2})");
                }
                else
                {
                    Console.WriteLine($"({line1x2}, {line1y2})({line1x1}, {line1y1})");
                }
            }
            else
            {
                if (isPointOneClosestToCenter(line1x1, line1y1, line1x2, line1y2))
                {
                    Console.WriteLine($"({line2x1}, {line2y1})({line2x2}, {line2y2})");
                }
                else
                {
                    Console.WriteLine($"({line2x2}, {line2y2})({line2x1}, {line2y1})");
                }
            }

           //Console.WriteLine(line1Lenght);
           //Console.WriteLine(line2Lenght);
        }

        public static double LineLenght(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x1 - x2)*(x1 - x2) + (y1 - y2)*(y1 - y2));
        }

        public static bool isPointOneClosestToCenter(double x1, double y1, double x2, double y2)
        {

            double distancePoint1 = Math.Sqrt(x1 * x1 + y1 * y1);
            double distancePoint2 = Math.Sqrt(x2 * x2 + y2 * y2);
            if (distancePoint1 <= distancePoint2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
