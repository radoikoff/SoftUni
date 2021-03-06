﻿
public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.fireAffinity = fireAffinity;
    }

    public int FireAffinity
    {
        get { return fireAffinity; }
        //protected set { fireAffinity = value; }
    }

    public override int GetMonumentBonus()
    {
        return this.FireAffinity;
    }

    public override string ToString()
    {
        return $"###Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}";
    }
}

