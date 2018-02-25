using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Length cannot be zero or negative.");
            }
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Width cannot be zero or negative.");
            }
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Height cannot be zero or negative.");
            }
            height = value;
        }
    }


    public double SurfaceArea()
    {
        return 2 * length * width + 2 * length * height + 2 * width * height;
    }

    public double LateralSurfaceArea()
    {
        return 2 * length * height + 2 * width * height;
    }

    public double Volume()
    {
        return length * width * height;
    }
}
