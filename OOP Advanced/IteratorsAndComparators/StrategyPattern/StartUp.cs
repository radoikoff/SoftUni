using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var setOne = new SortedSet<Person>(new NameComparer());
        var setTwo = new SortedSet<Person>(new AgeComparer());

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] args = Console.ReadLine().Split();
            string name = args[0];
            int age = int.Parse(args[1]);

            setOne.Add(new Person(name, age));
            setTwo.Add(new Person(name, age));
        }

        foreach (var person in setOne)
        {
            Console.WriteLine(person);
        }

        foreach (var person in setTwo)
        {
            Console.WriteLine(person);
        }
    }
}

