using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithAbstraction
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] tokens = command.Split();
                var department = tokens[0];
                var doctorFirstName = tokens[1];
                var doctorLastName = tokens[2];
                var pacient = tokens[3];
                var doctorFullName = doctorFirstName + doctorLastName;

                if (!doctors.ContainsKey(doctorFullName))
                {
                    doctors.Add(doctorFullName, new List<string>());
                }
                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<List<string>>());
                    for (int room = 0; room < 20; room++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool imaMqsto = departments[department].SelectMany(x => x).Count() < 60;
                if (imaMqsto)
                {
                    int roomNo = 0;
                    doctors[doctorFullName].Add(pacient);
                    for (int roomCounter = 0; roomCounter < departments[department].Count; roomCounter++)
                    {
                        if (departments[department][roomCounter].Count < 3)
                        {
                            roomNo = roomCounter;
                            break;
                        }
                    }
                    departments[department][roomNo].Add(pacient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int staq;
                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out staq))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, departments[args[0]][staq - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join(Environment.NewLine, doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}

