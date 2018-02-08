using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main()
        {
            var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine().Trim();
            while (input != "Party!")
            {
                var tokens = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = tokens[0];
                string criteria = tokens[1];
                string pattern = tokens[2];
                switch (command)
                {
                    case "Double":
                        for (int i = 0; i < names.Count; i++)
                        {
                            if (checkFunc(names[i],criteria, pattern))
                            {
                                names.Insert(i + 1, names[i]);
                                i++;
                            }
                            
                        }
                        //var moreNames = names.Where(n => checkFunc(n, criteria, pattern)).ToList();
                        //names.AddRange(moreNames);
                        break;
                    case "Remove":
                        names.RemoveAll(n => checkFunc(n, criteria, pattern));
                        break;
                }


                input = Console.ReadLine().Trim();
            }
            if (names.Count != 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        private static Func<string, string, string, bool> checkFunc = (string name, string criteria, string pattern) =>
        {
            switch (criteria)
            {
                case "StartsWith":
                    if (name.StartsWith(pattern))
                        return true;
                    break;
                case "EndsWith":
                    if (name.EndsWith(pattern))
                        return true;
                    break;
                case "Length":
                    int lenght = int.Parse(pattern);
                    if (name.Length == lenght)
                        return true;
                    break;
            }
            return false;
        };
    }
}
