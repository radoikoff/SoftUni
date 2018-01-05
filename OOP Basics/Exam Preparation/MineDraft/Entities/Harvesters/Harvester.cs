using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Harvester
{

    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentOutOfRangeException(nameof(EnergyRequirement));
            }
            energyRequirement = value;
        }
    }


    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(OreOutput));
            }
            oreOutput = value;
        }
    }


    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Ore Output: {oreOutput}");
        sb.Append($"Energy Requirement: {energyRequirement}");

        return sb.ToString();
    }

}

