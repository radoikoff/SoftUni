using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen : Inhabitant, IBirtable
{
    public Citizen(string name, int age, string id, string birthDate)
        : base(id)
    {
        Name = name;
        Age = age;
        BirthDate = birthDate;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string BirthDate { get; private set; }
}

