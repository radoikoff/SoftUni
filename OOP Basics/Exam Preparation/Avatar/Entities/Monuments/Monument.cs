
public abstract class Monument
{
    private string name;

    public Monument(string name)
    {
        this.name = name;
    }

    public string Name
    {
        get { return name; }
        //protected set { name = value; }
    }

    public abstract int GetMonumentBonus();
}

