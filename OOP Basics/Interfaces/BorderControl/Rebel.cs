using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Rebel : IBuyer, IBirtable
{
    private int food;

    public Rebel(string name, int age, string birthDate)
    {
        Food = 0;
        BirthDate = birthDate;
        Name = name;
        Age = Age;
    }

    public string BirthDate { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public int Food
    {
        get { return food; }
        private set { food = value; }
    }


    public void BuyFood()
    {
        this.food += 5;
    }

}
