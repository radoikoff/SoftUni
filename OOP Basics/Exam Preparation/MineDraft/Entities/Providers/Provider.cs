using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentOutOfRangeException(nameof(EnergyOutput));
            }
            energyOutput = value;
        }
    }


    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }


    public override string ToString()
    {
        return $"Energy Output: {energyOutput}";
    }

}

