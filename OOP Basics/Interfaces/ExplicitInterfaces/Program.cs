using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();
            IPerson citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
            Console.WriteLine(citizen.GetName());
            IResident citizen2 = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
            Console.WriteLine(citizen2.GetName());
        }
    }
}

