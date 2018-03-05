using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Repair
{
    public Repair(string partName, int hours)
    {
        PartName = partName;
        Hours = hours;
    }

    public string PartName { get; private set; }
    public int Hours { get; private set; }

    public override string ToString()
    {
        return $"Part Name: {PartName} Hours Worked: {Hours}";
    }
}

