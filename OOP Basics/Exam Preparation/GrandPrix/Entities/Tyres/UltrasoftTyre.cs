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
        protected set { this.grip = value; }
    }

    public override double Degradation
    {
        get { return base.Degradation; }

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentOutOfRangeException("Blown Tyre");
            }
            base.Degradation = value;
        }
    }

    public override void SetDegradation()
    {
        base.Degradation -= base.Hardness + this.Grip;
    }
}

