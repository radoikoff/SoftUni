using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main()
        {
            var sorted = new SortedSet<Person>();
            var hash = new HashSet<Person>();

            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                string[] args = Console.ReadLine().Split();
                string name = args[0];
                int age = int.Parse(args[1]);

                Person person = new Person(name, age);
                sorted.Add(person);
                hash.Add(person);
            }

            Console.WriteLine(sorted.Count);
            Console.WriteLine(hash.Count);
        }
    }
}
