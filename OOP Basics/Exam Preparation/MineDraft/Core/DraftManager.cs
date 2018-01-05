using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DraftManager
{
    private HashSet<Harvester> harvesters;
    private HashSet<Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private double modeCorrectionEnergyReq;
    private double modeCorrectionOreOutput;

    public DraftManager()
    {
        this.harvesters = new HashSet<Harvester>();
        this.providers = new HashSet<Provider>();
        modeCorrectionEnergyReq = 1.0;
        modeCorrectionOreOutput = 1.0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            harvesters.Add(HarvesterFactory.Create(arguments));
            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return $"Harvester is not registered, because of it's {ex.ParamName}";
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            providers.Add(ProviderFactory.Create(arguments));
            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentOutOfRangeException ex)
        {
            return $"Provider is not registered, because of it's {ex.ParamName}";
        }
    }

    public string Day()
    {
        StringBuilder sb = new StringBuilder();

        double summedEnergyOutput = providers.Sum(p => p.EnergyOutput);
        double summedEnergyRequirements = harvesters.Sum(h => h.EnergyRequirement * modeCorrectionEnergyReq);
        double summedOreOutput = 0;
        totalStoredEnergy += summedEnergyOutput;

        //mining begin
        if (totalStoredEnergy >= summedEnergyRequirements)
        {
            totalStoredEnergy -= summedEnergyRequirements;
            summedOreOutput = harvesters.Sum(h => h.OreOutput * modeCorrectionOreOutput);
            totalMinedOre += summedOreOutput;
        }

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {summedEnergyOutput}");
        sb.Append($"Plumbus Ore Mined: {summedOreOutput}");
        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];

        switch (mode)
        {
            case "Full":
                modeCorrectionEnergyReq = 1.0;
                modeCorrectionOreOutput = 1.0;
                break;
            case "Half":
                modeCorrectionEnergyReq = 0.6;
                modeCorrectionOreOutput = 0.5;
                break;
            case "Energy":
                modeCorrectionEnergyReq = 0.0;
                modeCorrectionOreOutput = 0.0;
                break;
        }

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (harvesters.Any(h => h.Id.Equals(id)))
        {
            return harvesters.First(h => h.Id.Equals(id)).ToString();
        }
        else if (providers.Any(h => h.Id.Equals(id)))
        {
            return providers.First(h => h.Id.Equals(id)).ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }


    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        sb.Append($"Total Mined Plumbus Ore: {totalMinedOre}");
        return sb.ToString();
    }

}

