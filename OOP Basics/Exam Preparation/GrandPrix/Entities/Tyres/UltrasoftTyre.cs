using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        this.Grip = grip;
    }

    private double grip;

    public double Grip
    {
        get { return grip; }
        set
        {
            if (value >= 0)
            {
                this.grip = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }

    public override double Degradation
    {
        get { return base.Degradation; }

        set
        {
            if (value >= 30)
            {
                base.Degradation = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Blown Tyre");
            }
        }
    }

    public override void SetDegradation()
    {
        Degradation -= Hardness + Grip;
    }
}

