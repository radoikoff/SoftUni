using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class HarvesterFactory
{
    public static Harvester Create(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        switch (type)
        {
            case "Sonic":
                int sonicFactor = int.Parse(arguments[4]);
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                return null;
        }
    }
}

