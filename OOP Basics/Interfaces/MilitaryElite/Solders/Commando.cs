using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Commando : SpecialisedSoldier
{
    public Commando(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<Mission>();
    }

    private List<Mission> missions;

    public IReadOnlyList<Mission> Missions
    {
        get { return missions; }
    }

    public void AddMission(string codeName, string state)
    {
        if (state == "inProgress" || state == "Finished")
        {
            this.missions.Add(new Mission(codeName, state));
        }
    }

    public void CompleteMission()
    {
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());
        sb.AppendLine("Missions:");
        foreach (var mission in this.missions)
        {
            sb.AppendLine("  " + mission.ToString());
        }

        return sb.ToString().Trim();
    }
}

