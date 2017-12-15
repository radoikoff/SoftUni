
public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.name = name;
        this.power = power;
    }

    public int Power
    {
        get { return power; }
        //protected set { power = value; }
    }


    public string Name
    {
        get { return name; }
        //protected set { name = value; }
    }

    public abstract double GetTotalPower();
}

