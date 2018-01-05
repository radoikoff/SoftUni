using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) : base(id, energyOutput)
    {
        base.EnergyOutput += base.EnergyOutput * 50 / 100;
    }

    public override string ToString()
    {
        return $"Pressure Provider - {base.Id}" + Environment.NewLine + base.ToString();
    }
}

