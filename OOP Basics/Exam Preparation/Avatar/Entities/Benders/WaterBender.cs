﻿
public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity)
        : base(name, power)
    {
        this.waterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return waterClarity; }
        //protected set { waterClarity = value; }
    }

    public override double GetTotalPower()
    {
        return base.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return $"###Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:f2}";
    }
}

