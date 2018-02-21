using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Family
{
    public List<Person> family;

    public Family()
    {
        family = new List<Person>();
    }

    public void AddMember(Person member)
    {
        if (!family.Any(m => m.Age == member.Age && m.Name == member.Name))
        {
            family.Add(member);
        }
    }

    public Person GetOldestMember()
    {
        return family.OrderByDescending(m => m.Age).FirstOrDefault();
    }
}

