using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
        : base(fuelQuantity, fuelConsumptionPerKm += 1.6, tankCapacity)
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
        if (fuelAmount <= 0)
        {
            throw new ArgumentException($"Fuel must be a positive number");
        }
        if (fuelAmount > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }
        this.FuelQuantity += fuelAmount * 0.95;
    }

    public override string ToString()
    {
        return $"Truck: {base.FuelQuantity:F2}";
    }
}

