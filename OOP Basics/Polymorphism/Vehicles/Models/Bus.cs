using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        var consumedFuel = distance * (FuelConsumptionPerKm + 1.4);
        if (FuelQuantity >= consumedFuel)
        {
            FuelQuantity -= consumedFuel;
            return $"Bus travelled {distance} km";
        }
        return $"Bus needs refueling";
    }

    public string DriveEmpty(double distance)
    {
        var consumedFuel = distance * FuelConsumptionPerKm;
        if (FuelQuantity >= consumedFuel)
        {
            FuelQuantity -= consumedFuel;
            return $"Bus travelled {distance} km";
        }
        return $"Bus needs refueling";
    }

    public override string ToString()
    {
        return $"Bus: {base.FuelQuantity:F2}";
    }
}

