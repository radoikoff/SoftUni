using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            var input = Console.ReadLine();
            while (!input.Equals("stop"))
            {
                if (input.Equals("search"))
                {
                    input = Console.ReadLine();
                    while (!input.Equals("stop"))
                    {
                        if (phonebook.ContainsKey(input))
                        {
                            Console.WriteLine($"{input} -> {phonebook[input]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {input} does not exist.");
                        }
                        input = Console.ReadLine();
                    }
                    break;
                }
                else
                {
                    var tokens = input.Split('-');
                    if (!phonebook.ContainsKey(tokens[0]))
                    {
                        phonebook.Add(tokens[0], string.Empty);
                    }

                    phonebook[tokens[0]] = tokens[1];
                }

                input = Console.ReadLine();
            }
        }
    }
}
