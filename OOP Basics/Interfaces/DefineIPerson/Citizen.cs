using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen : IPerson, IIdentifiable, IBirthable
{
    private string name;
    private int age;
    private string id;
    private string birthdate;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
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

    public string Id
    {
        get { return id; }

        private set { id = value; }
    }

    public string Birthdate
    {
        get { return birthdate; }

        private set { birthdate = value; }
    }
}

