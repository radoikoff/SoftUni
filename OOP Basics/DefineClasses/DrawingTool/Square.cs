using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingTool
{
    public class Square : Shape
    {
        public Square(int side)
        {
            base.SideA = side;
            base.SideB = side;
        }
    }
}
