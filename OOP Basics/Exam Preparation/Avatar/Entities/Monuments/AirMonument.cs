
public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity)
        : base(name)
    {
        this.airAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        //protected set { airAffinity = value; }
    }

    public override int GetMonumentBonus()
    {
        return this.AirAffinity;
    }

    public override string ToString()
    {
        return $"###Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}";
    }

}

