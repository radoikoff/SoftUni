using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var soldiers = new List<Soldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var SolderTpe = tokens[0];
            var id = tokens[1];
            var firstName = tokens[2];
            var lastName = tokens[3];
            double salary;

            tokens = tokens.Skip(4).ToArray();

            switch (SolderTpe)
            {
                case "Private":
                    salary = double.Parse(tokens[0]);
                    soldiers.Add(new Private(id, firstName, lastName, salary));
                    break;
                case "LeutenantGeneral":
                    salary = double.Parse(tokens[0]);
                    var ltGeneral = new LeutenantGeneral(id, firstName, lastName, salary);
                    foreach (var privateId in tokens)
                    {
                        ltGeneral.AddPrivate(soldiers.FirstOrDefault(p => p.Id == privateId));
                    }
                    soldiers.Add(ltGeneral);
                    break;
                case "Engineer":
                    salary = double.Parse(tokens[0]);
                    var corps = tokens[1];
                    try //check for corps
                    {
                        var engineer = new Engineer(id, firstName, lastName, salary, corps);
                        for (int i = 2; i < tokens.Length - 1; i += 2)
                        {
                            engineer.AddRepair(tokens[i], int.Parse(tokens[i + 1]));
                        }
                        soldiers.Add(engineer);
                    }
                    catch (ArgumentException)
                    {
                    }
                    break;
                case "Commando":
                    salary = double.Parse(tokens[0]);
                    corps = tokens[1];
                    try //check for corps
                    {
                        var commando = new Commando(id, firstName, lastName, salary, corps);
                        for (int i = 2; i < tokens.Length - 1; i += 2)
                        {
                            commando.AddMission(tokens[i], tokens[i + 1]);
                        }
                        soldiers.Add(commando);
                    }
                    catch (ArgumentException)
                    {
                    }
                    break;
                case "Spy":
                    var codeNumber = int.Parse(tokens[0]);
                    soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                    break;
            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.ToString());
        }
    }
}

