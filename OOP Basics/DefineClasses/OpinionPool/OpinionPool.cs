using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class OpinionPool
{
    public static void Main()
    {
        var family = new List<Person>();
        var number = int.Parse(System.Console.ReadLine());
        for (int counter = 0; counter < number; counter++)
        {
            var data = Console.ReadLine().Split();
            var name = data[0];
            var age = int.Parse(data[1]);
            family.Add(new Person(name, age));
        }

        foreach (var person in family.Where(p => p.Age > 30).OrderBy(p => p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }


    }
}

