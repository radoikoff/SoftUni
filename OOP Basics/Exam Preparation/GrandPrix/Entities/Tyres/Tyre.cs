using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Tyre
{

    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Blown Tyre");
            }
            this.degradation = value;
        }
    }


    public double Hardness
    {
        get { return hardness; }
        protected set { hardness = value; }
    }


    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public virtual void SetDegradation()
    {
        this.Degradation -= this.Hardness;
    }

}

