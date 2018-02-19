using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double leftCoordinate;
        private double topCoordinate;

        public Rectangle(string id, double width, double height, double leftCoordinate, double topCoordinate)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.leftCoordinate = leftCoordinate;
            this.topCoordinate = topCoordinate;
        }

        public double TopCoordinate
        {
            get { return topCoordinate; }
            set { topCoordinate = value; }
        }

        public double LeftCoordinate
        {
            get { return leftCoordinate; }
            set { leftCoordinate = value; }
        }


        public double Height
        {
            get { return height; }
            set { height = value; }
        }


        public double Width
        {
            get { return width; }
            set { width = value; }
        }


        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public bool IsIntersect(Rectangle rectangle)
        {
            bool isIntersect = false;

            //A.X1 < B.X2: 
            //A.X2 > B.X1: 
            //A.Y1 < B.Y2: 
            //A.Y2 > B.Y1: 

            if (Math.Abs(this.leftCoordinate) < Math.Abs(rectangle.LeftCoordinate + rectangle.Width))
            {
                if (Math.Abs(this.leftCoordinate + this.width) >= Math.Abs(rectangle.LeftCoordinate))
                {
                    if (this.topCoordinate < Math.Abs((rectangle.TopCoordinate + rectangle.Height)))
                    {
                        if (Math.Abs(this.TopCoordinate + this.height) >= Math.Abs(rectangle.TopCoordinate))
                        {
                            isIntersect = true;
                        }
                    }
                }
            }

            return isIntersect;
        }

    }
}
