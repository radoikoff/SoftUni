using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LeutenantGeneral : Private
{
    private List<Soldier> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.privates = new List<Soldier>();
    }

    public IReadOnlyList<Soldier> Privates
    {
        get { return privates; }
        //set { privates = value; }
    }

    public void AddPrivate(Soldier privateSolder)
    {
        if (privateSolder != null)
        {
            this.privates.Add(privateSolder);
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach (var privateSolder in this.privates)
        {
            sb.AppendLine("  " + privateSolder.ToString());
        }

        return sb.ToString().Trim();
    }

}

