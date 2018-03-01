using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class Student : Human
{
    public Student(string firstName, string lastName, string facilityNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facilityNumber;
    }

    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (IsNumberInvalid(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"Faculty number: {FacultyNumber}" + Environment.NewLine;
    }

    private bool IsNumberInvalid(string value)
    {
        string pattern = @"^([0-9a-zA-Z]{5,10})$";

        var regex = new Regex(pattern);

        var match = regex.Match(value);

        return !match.Success;
    }

}

