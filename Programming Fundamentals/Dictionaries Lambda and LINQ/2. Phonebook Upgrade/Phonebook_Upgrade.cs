using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Phonebook_Upgrade
{
    class Phonebook_Upgrade
    {
        public static void Main()
        {
            var phonebook = new SortedDictionary<string, string>();
            var input = Console.ReadLine().Split(' ').ToList();
            while (input[0].ToLower() != "end")
            {
                switch (input[0].ToLower())
                {
                    case "a":
                        phonebook[input[1]] = input[2];
                        break;
                    case "s":
                        if (phonebook.ContainsKey(input[1]))
                        {
                            Console.WriteLine($"{input[1]} -> {phonebook[input[1]]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {input[1]} does not exist.");
                        }
                        break;
                    case "listall":
                        foreach (var pair in phonebook)
                        {
                            Console.WriteLine($"{pair.Key} -> {pair.Value}");
                        }
                        break;

                }
                input = Console.ReadLine().Split(' ').ToList();
            }
        }
    }
}
