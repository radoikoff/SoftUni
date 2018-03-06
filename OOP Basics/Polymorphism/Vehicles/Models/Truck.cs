using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        : base(fuelQuantity, fuelConsumptionPerKm += 1.6)
    {
    }

    public override string Drive(double distance)
    {
        var consumedFuel = distance * FuelConsumptionPerKm;
        if (FuelQuantity >= consumedFuel)
        {
            FuelQuantity -= consumedFuel;
            return $"Truck travelled {distance} km";
        }
        return $"Truck needs refueling";
    }

    public override void Refuel(double fuelAmount)
    {
        this.FuelQuantity += fuelAmount * 0.95;
    }

    public override string ToString()
    {
        return $"Truck: {base.FuelQuantity:F2}";
    }
}

