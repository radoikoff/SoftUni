using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var inhabitants = new List<IBuyer>();

        var number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            var tokens = Console.ReadLine().Split();

            if (tokens.Length == 4)
            {
                inhabitants.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
            }
            else if (tokens.Length == 3)
            {
                inhabitants.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var inhabitant = inhabitants.FirstOrDefault(i => i.Name.Equals(input));
            if (inhabitant != null)
            {
                inhabitant.BuyFood();
            }
        }

        Console.WriteLine(inhabitants.Sum(i => i.Food));


    }
}
