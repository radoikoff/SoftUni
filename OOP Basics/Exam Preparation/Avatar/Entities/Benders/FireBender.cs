
public class FireBender : Bender
{
    private double heatAggression;

    public FireBender(string name, int power, double heatAggression)
        : base(name, power)
    {
        this.heatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return heatAggression; }
        //protected set { heatAggression = value; }
    }

    public override double GetTotalPower()
    {
        return base.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return $"###Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:f2}";
    }
}

