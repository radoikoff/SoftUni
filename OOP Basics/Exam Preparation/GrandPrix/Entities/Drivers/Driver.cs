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
    //private double speed;

    public Driver(string name, Car car)
    {
        this.name = name;
        this.Car = car;
        //this.speed = (this.car.Hp + this.car.Tyre.Degradation) / this.car.FuelAmount;
    }

    public virtual double Speed
    {
        get { return (this.car.Hp + this.car.Tyre.Degradation) / this.car.FuelAmount; }
        //protected set { speed = value; }
    }


    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { fuelConsumptionPerKm = value; }
    }


    public Car Car
    {
        get { return car; }
        set
        {
            if (car != null)
            {
                car = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }


    public double TotalTime
    {
        get { return this.totalTime; }
        set
        {
            if (value > 0)
            {
                this.totalTime = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }


    public string Name
    {
        get { return name; }
        //set { name = value; }
    }

    public abstract double GetOvertakeTime();

    public abstract bool GetCrashedDuringOvertake(string weather);
}

