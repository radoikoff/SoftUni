using System;

namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main()
        {
            string figureType = Console.ReadLine().ToLower();
            if (figureType == "triangle" || figureType == "rectangle") 
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", FigureArea(side, height, figureType));
            }
            else if (figureType == "square" || figureType == "circle")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine("{0:f2}", FigureArea(side, 0, figureType));
            }
        }

        public static double FigureArea(double side, double height, string parameter)
        {
            double area = 0;
            switch (parameter)
            {
                case "triangle":
                    area = side * height / 2;
                    break;
                case "rectangle":
                    area = side * height;
                    break;
                case "square":
                    area = side * side;
                    break;
                case "circle":
                    area = Math.PI * side * side;
                    break;
            }
            return area;
        }


    }
}
