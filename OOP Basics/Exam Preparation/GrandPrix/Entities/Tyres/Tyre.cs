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

    public Tyre(string name, double hardness)
    {
        this.name = name;
        this.hardness = hardness;
        this.degradation = 100;
    }

    public virtual double Degradation
    {
        get { return this.degradation; }
        set
        {
            if (value >= 0)
            {
                this.degradation = value; ;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Blown Tyre");
            }
        }
    }


    public double Hardness
    {
        get { return hardness; }
        //set { hardness = value; }
    }


    public string Name
    {
        get { return name; }
        //set { name = value; }
    }

    public abstract void SetDegradation();

}

