using System;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Circle
{
    public Point Center { get; set; }
    public int Radius { get; set; }
}

namespace _3.Intersection_of_Circles
{
    class Program
    {
        public static void Main()
        {
            Circle firstCircle = new Circle();
            Circle secondCircle = new Circle();
            Point firstCircleCenter = new Point();
            Point secondCircleCenter = new Point();

            var firstCircleInput = Console.ReadLine().Split();
            firstCircleCenter.X = int.Parse(firstCircleInput[0]);
            firstCircleCenter.Y = int.Parse(firstCircleInput[1]);
            firstCircle.Center = firstCircleCenter;
            firstCircle.Radius = int.Parse(firstCircleInput[2]);

            var secondCircleInput = Console.ReadLine().Split();
            secondCircleCenter.X = int.Parse(secondCircleInput[0]);
            secondCircleCenter.Y = int.Parse(secondCircleInput[1]);
            secondCircle.Center = secondCircleCenter;
            secondCircle.Radius = int.Parse(secondCircleInput[2]);

            if (IsCirclesIntersect(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static bool IsCirclesIntersect(Circle firstCircle, Circle secondCircle)
        {
            var centerDistance = DistanceBetweenTwoPoints(firstCircle.Center, secondCircle.Center);
            if (centerDistance <= firstCircle.Radius + secondCircle.Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double DistanceBetweenTwoPoints(Point p1, Point p2)
        {
            int deltaX = p2.X - p1.X;
            int deltaY = p2.Y - p1.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
