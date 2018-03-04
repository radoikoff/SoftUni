using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var name = Console.ReadLine();
        var car = new Ferrari(name);
        Console.WriteLine($"{car.Model}/{car.PushBrake()}/{car.PushGas()}/{car.DriverName}");
    }
}
