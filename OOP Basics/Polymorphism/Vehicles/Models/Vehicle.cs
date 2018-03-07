using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Vehicle
{
    public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, int tankCapacity)
    {
        FuelConsumptionPerKm = fuelConsumptionPerKm;
        TankCapacity = tankCapacity;
        if (fuelQuantity <= TankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
        }
    }

    public double FuelQuantity { get;  protected set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public int TankCapacity { get; private set; }


    public abstract string Drive(double distance);

    public virtual void Refuel(double fuelAmount)
    {
        if (fuelAmount <= 0)
        {
            throw new ArgumentException($"Fuel must be a positive number");
        }
        if (fuelAmount > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
        }
        this.FuelQuantity += fuelAmount;
    }

}

