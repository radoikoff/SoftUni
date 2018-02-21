using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTool
{
    public class Rectangle : Shape
    {
        public Rectangle(int sideA, int sideB)
        {
            base.SideA = sideA;
            base.SideB = sideB;
        }
    }
}
