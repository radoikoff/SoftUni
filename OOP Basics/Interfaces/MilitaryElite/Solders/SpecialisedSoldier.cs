﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class SpecialisedSoldier : Private
{
    public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        this.Corps = corps;
    }

    private string corps;

    public string Corps
    {
        get { return corps; }
        private set
        {
            if (value != "Airforces" && value != "Marines")
            {
                throw new ArgumentException();
            }
            this.corps = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"Corps: {Corps}" + Environment.NewLine;
    }
}
