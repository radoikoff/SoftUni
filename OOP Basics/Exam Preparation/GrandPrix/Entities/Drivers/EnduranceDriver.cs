using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car)
        : base(name, car)
    {
        base.FuelConsumptionPerKm = 1.5;
    }

    public override double GetOvertakeTime()
    {
        if (base.Car.Tyre.Name == "Hard")
        {
            return 3.0;
        }
        return 2.0;
    }

    public override bool GetCrashedDuringOvertake(string weather)
    {
        if (weather == "Rainy" && base.Car.Tyre.Name == "Hard")
        {
            return true;
        }
        return false;
    }
}

