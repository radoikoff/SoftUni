using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Array_Manipulator
{
    public static class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var command = Console.ReadLine();
            while (command != "print")
            {
                var parameters = command.Split(' ');
                switch (parameters[0].ToLower())
                {
                    case "add":
                        int index = int.Parse(parameters[1]);
                        int value = int.Parse(parameters[2]);
                        if (index < numbers.Count && index >= 0)
                        {
                            numbers.Insert(index, value);
                        }
                        else
                        {
                            numbers.Add(value);
                        }
                        break;
                    case "addmany":
                        int index2 = int.Parse(parameters[1]);
                        if (index2 <= numbers.Count)
                        {
                            numbers.InsertRange(index2, parameters.Skip(2).Select(int.Parse).ToList());
                        }
                        else
                        {
                            numbers.AddRange(parameters.Skip(2).Select(int.Parse).ToList());
                        }
                        break;
                    case "contains":
                        int pos = int.Parse(parameters[1]);
                        if (numbers.Contains(pos))
                        {
                            Console.WriteLine(numbers.IndexOf(pos));
                        }
                        else
                        {
                            Console.WriteLine("-1");
                        }
                        break;
                    case "remove":
                        int ind = int.Parse(parameters[1]);
                        if (ind < numbers.Count && ind >= 0)
                        {
                            numbers.RemoveAt(ind);
                        }
                        break;
                    case "shift":
                        for (int i = 0; i < int.Parse(parameters[1]); i++)
                        {
                            numbers.Add(numbers[0]);
                            numbers.RemoveAt(0);
                        }
                        break;
                    case "sumpairs":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (i + 1 < numbers.Count)
                            {
                                numbers[i] += numbers[i + 1];
                                numbers.RemoveAt(i + 1);
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }
    }
}
