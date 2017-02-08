using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Phonebook
{
    class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();
            var input = Console.ReadLine().Split(' ').ToList();
            while (input[0].ToLower() != "end")
            {
                switch (input[0].ToLower())
                {
                    case "a":
                        phonebook[input[1]] = input[2];
                        break;
                    case "s":
                        if (phonebook.ContainsKey (input[1]))
                        {
                            Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {input[1]} does not exist.");
                        }
                        break;
                }
                input = Console.ReadLine().Split(' ').ToList();
            }
        }
    }
}
