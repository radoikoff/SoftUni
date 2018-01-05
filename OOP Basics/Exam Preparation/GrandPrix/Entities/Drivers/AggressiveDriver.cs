using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car)
        : base(name, car)
    {
        base.FuelConsumptionPerKm = 2.7;
    }

    public override double Speed
    {
        get
        {
            return base.Speed * 1.3;
        }
    }

    public override double GetOvertakeTime()
    {
        if (base.Car.Tyre.Name == "Ultrasoft")
        {
            return 3.0;
        }
        return 2.0;
    }

    public override bool GetCrashedDuringOvertake(string weather)
    {
        if (weather == "Foggy" && base.Car.Tyre.Name == "Ultrasoft")
        {
            return true;
        }
        return false;
    }
}

