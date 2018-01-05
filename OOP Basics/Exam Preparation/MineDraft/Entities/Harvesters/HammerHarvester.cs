using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput += base.OreOutput * 200 / 100;
        base.EnergyRequirement += base.EnergyRequirement * 100 / 100;
    }

    public override string ToString()
    {
        return $"Hammer Harvester - {base.Id}" + Environment.NewLine + base.ToString();
    }
}

