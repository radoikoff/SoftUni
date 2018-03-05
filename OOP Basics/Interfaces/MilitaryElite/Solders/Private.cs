using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Private : Soldier
{
    public Private(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        Salary = salary;
    }

    public double Salary { get; private set; }

    public override string ToString()
    {
        return base.ToString() + " " + $"Salary: {Salary:F2}"; // + Environment.NewLine;
    }
}

