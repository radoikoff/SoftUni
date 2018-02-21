using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTool
{
    public class Program
    {
        public static void Main()
        {
            var shapeType = Console.ReadLine();

            if (shapeType == "Rectangle")
            {
                var sideA = int.Parse(Console.ReadLine());
                var sideB = int.Parse(Console.ReadLine());

                var drawingTool = new DrawingTool(new Rectangle(sideA, sideB));
                drawingTool.Draw();
            }
            else if (shapeType == "Square")
            {
                var side = int.Parse(Console.ReadLine());

                var drawingTool = new DrawingTool(new Square(side));
                drawingTool.Draw();
            }

            
        }
    }
}
