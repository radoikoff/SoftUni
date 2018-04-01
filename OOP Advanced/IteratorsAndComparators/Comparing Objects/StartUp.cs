using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var args = input.Split();
            var name = args[0];
            var age = int.Parse(args[1]);
            var town = args[2];

            people.Add(new Person(name, age, town));

        }

        int personIndex = int.Parse(Console.ReadLine());

        string result = CheckForEqualPeoples(people, personIndex);
        Console.WriteLine(result);

    }

    private static string CheckForEqualPeoples(List<Person> people, int personIndex)
    {
        int numberOfEqualPeople = 0;

        Person personToCompare = people[personIndex - 1];

        foreach (var person in people)
        {
            int result = person.CompareTo(personToCompare);
            if (result == 0)
            {
                numberOfEqualPeople++;
            }
        }

        string output;
        if (numberOfEqualPeople != 1)
        {
            output = $"{numberOfEqualPeople} {people.Count - numberOfEqualPeople} {people.Count}";
        }
        else
        {
            output = "No matches";
        }

        return output;
    }
}

