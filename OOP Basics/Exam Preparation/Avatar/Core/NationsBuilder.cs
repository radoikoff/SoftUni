using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private List<string> wars;

    public NationsBuilder()
    {
        this.nations = new Dictionary<string, Nation>
        {
            {"Air", new Nation() },
            {"Water", new Nation() },
            {"Fire", new Nation() },
            {"Earth", new Nation() }
        };
        this.wars = new List<string>();
    }


    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double secondaryParameter = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                this.nations[type].AddBender(new AirBender(name, power, secondaryParameter));
                break;
            case "Water":
                this.nations[type].AddBender(new WaterBender(name, power, secondaryParameter));
                break;
            case "Fire":
                this.nations[type].AddBender(new FireBender(name, power, secondaryParameter));
                break;
            case "Earth":
                this.nations[type].AddBender(new EarthBender(name, power, secondaryParameter));
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        switch (type)
        {
            case "Air":
                this.nations[type].AddMonument(new AirMonument(name, affinity));
                break;
            case "Water":
                this.nations[type].AddMonument(new WaterMonument(name, affinity));
                break;
            case "Fire":
                this.nations[type].AddMonument(new FireMonument(name, affinity));
                break;
            case "Earth":
                this.nations[type].AddMonument(new EarthMonument(name, affinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{nationsType} Nation");
        sb.AppendLine(this.nations[nationsType].ToString());

        return sb.ToString().Trim();
    }

    public void IssueWar(string nationsType)
    {
        wars.Add(nationsType);
        var winnerPoints = nations.Values.Max(n => n.GetTotalPoints());

        foreach (var nation in nations)
        {
            if (nation.Value.GetTotalPoints() != winnerPoints)
            {
                nation.Value.ResetAll();
            }
        }
    }

    public string GetWarsRecord()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < wars.Count; i++)
        {
            sb.AppendLine($"War {i + 1} issued by {wars[i]}");
        }
        return sb.ToString().Trim();
    }

}

