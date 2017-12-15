using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        monuments.Add(monument);
    }

    public double GetTotalPoints()
    {
        var power = this.benders.Sum(b => b.GetTotalPower());
        var bonus = this.monuments.Sum(m => m.GetMonumentBonus());

        return power += power / 100 * bonus;
    }

    public void ResetAll()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        if (benders.Any())
        {
            sb.AppendLine("Benders:");
            foreach (var bender in benders)
            {
                sb.AppendLine(bender.ToString());
            }
        }
        else
        {
            sb.AppendLine("Benders: None");
        }

        if (monuments.Any())
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in monuments)
            {
                sb.AppendLine(monument.ToString());
            }
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }

        return sb.ToString().Trim();
    }




}

