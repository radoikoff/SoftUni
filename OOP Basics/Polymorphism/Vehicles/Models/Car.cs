using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm += 0.9, tankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        var consumedFuel = distance * FuelConsumptionPerKm;
        if (FuelQuantity >= consumedFuel)
        {
            FuelQuantity -= consumedFuel;
            return $"Car travelled {distance} km";
        }
        return $"Car needs refueling";
    }

    public override string ToString()
    {
        return $"Car: {base.FuelQuantity:F2}";
    }
    
}




