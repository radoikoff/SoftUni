using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.ParamName);
        }



    }
}


