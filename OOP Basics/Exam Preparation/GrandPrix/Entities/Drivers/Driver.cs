using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
        this.TotalTime = 0;
    }

    public virtual double Speed
    {
        get { return (this.car.Hp + this.car.Tyre.Degradation) / this.car.FuelAmount; }
    }


    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }


    public Car Car
    {
        get { return car; }
        protected set { car = value; }
    }


    public double TotalTime
    {
        get { return this.totalTime; }
        set { this.totalTime = value; }
    }


    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public abstract double GetOvertakeTime();

    public abstract bool GetCrashedDuringOvertake(string weather);
}

