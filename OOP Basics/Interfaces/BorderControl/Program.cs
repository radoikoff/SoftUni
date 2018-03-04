using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var inhabitants = new List<Inhabitant>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();

            if (tokens.Length == 3)
            {
                inhabitants.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
            else
            {
                inhabitants.Add(new Robot(tokens[0], tokens[1]));
            }
        }

        var fakeId = Console.ReadLine().Trim();

        foreach (var inhabitant in inhabitants.Where(i => i.Id.EndsWith(fakeId)))
        {
            Console.WriteLine(inhabitant.Id);
        }

    }
}
