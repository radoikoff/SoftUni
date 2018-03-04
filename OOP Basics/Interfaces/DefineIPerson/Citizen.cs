using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen : IPerson
{
    private string name;
    private int age;

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public int Age
    {
        get { return age; }
        private set { age = value; }
    }


    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

}

