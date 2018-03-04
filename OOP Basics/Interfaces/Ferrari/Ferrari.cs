using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ferrari : ICar
{
    public Ferrari(string driverName)
    {
        this.Model = "488-Spider";
        this.DriverName = driverName;
    }

    public string Model { get; set; }

    public string DriverName { get; set; }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public string PushBrake()
    {
        return "Brakes!";
    }

}

