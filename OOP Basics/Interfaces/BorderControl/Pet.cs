using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pet : IBirtable 
{
    public Pet(string name, string birthDate)
    {
        BirthDate = birthDate;
        Name = name;
    }

    public string BirthDate { get; private set; }
    public string Name { get; set; }
}

