using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Person
{
    private string name;
    private int age;

    public Person()
    {
        Name = "No Name";
        Age = 1;
    }

    public Person(int age)
    : this()
    {
        Age = age;
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }



    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{Name} {Age.ToString()}";
    }

}

