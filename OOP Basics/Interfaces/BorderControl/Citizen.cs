using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen : Inhabitant, IBirtable, IBuyer
{
    public Citizen(string name, int age, string id, string birthDate)
        : base(id)
    {
        Name = name;
        Age = age;
        BirthDate = birthDate;
        Food = 0;
    }

    public string Name { get; private set; }
    public int Age { get; private set; }
    public string BirthDate { get; private set; }

    private int food;

    public int Food
    {
        get { return food; }
        private set { food = value; }
    }


    public void BuyFood()
    {
        this.food += 10;

    }
}

