using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Mission
{
    public Mission(string codeName, string missionState)
    {
        CodeName = codeName;
        MissionState = missionState;
    }

    public string CodeName { get; private set; }
    public string MissionState { get; private set; }

    public override string ToString()
    {
        return $"Code Name: {CodeName} State: {MissionState}";
    }
}

