
public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.earthAffinity = earthAffinity;
    }

    public int EarthAffinity
    {
        get { return earthAffinity; }
        //protected set { earthAffinity = value; }
    }

    public override int GetMonumentBonus()
    {
        return this.EarthAffinity;
    }

    public override string ToString()
    {
        return $"###Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}";
    }
}

