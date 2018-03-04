using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var inhabitants = new List<IBirtable>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();

            if (tokens[0] == "Citizen")
            {
                inhabitants.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
            }
            //else if(tokens[0] == "Robot")
            //{
            //    inhabitants.Add(new Robot(tokens[1], tokens[2]));
            //}
            else if (tokens[0] == "Pet")
            {
                inhabitants.Add(new Pet(tokens[1], tokens[2]));
            }
        }

        var year = Console.ReadLine().Trim();

        foreach (var inhabitant in inhabitants.Where(i => i.BirthDate.EndsWith(year)))
        {
            Console.WriteLine(inhabitant.BirthDate);
        }

    }
}
