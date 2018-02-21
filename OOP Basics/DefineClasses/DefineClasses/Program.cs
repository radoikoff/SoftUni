using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var family = new Family();
        var number = int.Parse(System.Console.ReadLine());
        for (int counter = 0; counter < number; counter++)
        {
            var data = Console.ReadLine().Split();
            var name = data[0];
            var age = int.Parse(data[1]);
            family.AddMember(new Person(name, age));
        }

        Console.WriteLine(family.GetOldestMember().ToString());
    }
}

