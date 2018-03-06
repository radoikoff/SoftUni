using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumptionPerKm = fuelConsumptionPerKm;
    }

    public double FuelQuantity { get; protected set; }
    public double FuelConsumptionPerKm { get; protected set; }

    public abstract string Drive(double distance);

    public abstract void Refuel(double fuelAmount);

}

