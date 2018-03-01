using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length <= 2)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }


    public string FirstName
    {
        get { return firstName; }
        private set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length <= 3)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}" + Environment.NewLine + $"Last Name: {LastName}" + Environment.NewLine;
    }

}

