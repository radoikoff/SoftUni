using System;
using System.Collections.Generic;
using System.Text;


public class NameComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        int result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            result = x.Name[0].ToString().ToLower().CompareTo(y.Name[0].ToString().ToLower());
        }

        return result;
    }
}

