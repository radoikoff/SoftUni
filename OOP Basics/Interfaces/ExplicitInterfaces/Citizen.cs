﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Citizen : IPerson, IResident
{
    public Citizen(string name, string country, int age)
    {
        Name = name;
        Age = age;
        Country = country;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Country { get; private set; }

    string IResident.GetName()
    {
        return "Mr/Ms/Mrs " + Name;
    }
    string IPerson.GetName()
    {
        return Name;
    }
}

