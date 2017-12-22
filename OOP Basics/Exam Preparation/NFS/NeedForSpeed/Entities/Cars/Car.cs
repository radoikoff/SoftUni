using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.horsepower = horsepower;
        this.acceleration = acceleration;
        this.suspension = suspension;
        this.durability = durability;
    }

    public string Brand
    {
        get
        {
            return brand;
        }

        set
        {
            brand = value;
        }
    }

    public string Model
    {
        get
        {
            return model;
        }

        set
        {
            model = value;
        }
    }

    public int YearOfProduction
    {
        get
        {
            return yearOfProduction;
        }

        set
        {
            yearOfProduction = value;
        }
    }

    public int Horsepower
    {
        get
        {
            return horsepower;
        }

        set
        {
            horsepower = value;
        }
    }

    public int Acceleration
    {
        get
        {
            return acceleration;
        }

        set
        {
            acceleration = value;
        }
    }

    public int Suspension
    {
        get
        {
            return suspension;
        }

        set
        {
            suspension = value;
        }
    }

    public int Durability
    {
        get
        {
            return durability;
        }

        set
        {
            durability = value;
        }
    }

    public int OverallPerformance()
    {
        return (this.horsepower / this.acceleration) + (this.suspension + this.durability);
    }

    public int EnginePerformance()
    {
        return (this.horsepower / this.acceleration);
    }

    public int SuspensionPerformance()
    {
        return (this.suspension + this.durability);
    }

    internal virtual void Tune(int tuneIndex, string addOn)
    {
        this.horsepower += tuneIndex;
        this.suspension += tuneIndex / 2;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.brand} {this.model} {this.yearOfProduction}");
        sb.AppendLine($"{this.horsepower} HP, 100 m/h in {this.acceleration} s");
        sb.AppendLine($"{this.suspension} Suspension force, {this.durability} Durability");
        return sb.ToString().Trim();
    }

}

