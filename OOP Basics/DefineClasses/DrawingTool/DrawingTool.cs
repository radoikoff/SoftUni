using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTool
{
    public class DrawingTool
    {
        private Shape shape;

        public DrawingTool(Shape shape)
        {
            this.shape = shape;
        }

        public void Draw()
        {
            for (int i = 0; i < shape.SideB; i++)
            {
                if (i == 0 || i == shape.SideB - 1)
                {
                    Console.WriteLine($"|{new string('-', shape.SideA)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string(' ', shape.SideA)}|");
                }
            }
        }


    }
}
