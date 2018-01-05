using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) : base(id, energyOutput)
    {
    }

    public override string ToString()
    {
        return $"Solar Provider - {base.Id}" + Environment.NewLine + base.ToString();
    }
}

