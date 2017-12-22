using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private List<String> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        this.addOns = new List<string>();
        this.Horsepower += (this.Horsepower * 50) / 100;
        this.Suspension -= (this.Suspension * 25) / 100;
    }

    public IReadOnlyList<string> AddOns
    {
        get { return addOns.AsReadOnly(); }
    }

    public override string ToString()
    {
        string result = "";
        if (this.addOns.Any())
        {
            result = $"Add-ons: {string.Join(", ", this.addOns)}";
        }
        else
        {
            result = "Add-ons: None";
        }

        return base.ToString() + Environment.NewLine + result;
    }

    internal override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }
}

