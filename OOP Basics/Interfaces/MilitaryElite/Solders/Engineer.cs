using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engineer : SpecialisedSoldier
{
    public Engineer(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<Repair>();
    }

    private List<Repair> repairs;

    public IReadOnlyList<Repair> Repairs
    {
        get { return repairs; }
    }

    public void AddRepair(string part, int hours)
    {
        this.repairs.Add(new Repair(part, hours));
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.AppendLine("Repairs:");
        foreach (var repair in this.repairs)
        {
            sb.AppendLine("  " + repair.ToString());
        }

        return sb.ToString().Trim();
    }

}

