using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Car
{

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.hp = hp;
        this.FuelAmount = fuelAmount;
        this.tyre = tyre;
    }

    public Tyre Tyre
    {
        get { return tyre; }
        //set { tyre = value; }
    }


    public double FuelAmount
    {
        get { return fuelAmount; }
        set
        {
            if (value > 160)
            {
                this.fuelAmount = 160;
            }
            else if (value <= 0)
            {
                this.fuelAmount = 0;
                throw new ArgumentOutOfRangeException("Out of fuel");
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }


    public int Hp
    {
        get { return hp; }
        //set { hp = value; }
    }


}

