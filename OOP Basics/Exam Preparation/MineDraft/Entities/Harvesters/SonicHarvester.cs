using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        base.EnergyRequirement /= this.sonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }

    public override string ToString()
    {
        return $"Sonic Harvester - {base.Id}" + Environment.NewLine + base.ToString();
    }
}

