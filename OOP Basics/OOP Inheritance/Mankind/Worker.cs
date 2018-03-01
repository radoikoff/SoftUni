using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Worker : Human
{
    public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal weekSalary;
    private decimal workHoursPerDay;

    public decimal WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value > 12 || value < 1)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }


    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public decimal GetSalaryPerHour
    {
        get { return WeekSalary / (5 * WorkHoursPerDay); }
    }

    public override string ToString()
    {
        return base.ToString() + $"Week Salary: {WeekSalary:F2}" + Environment.NewLine +
                                 $"Hours per day: {WorkHoursPerDay:F2}" + Environment.NewLine +
                                 $"Salary per hour: {GetSalaryPerHour:F2}" + Environment.NewLine;

    }

}

