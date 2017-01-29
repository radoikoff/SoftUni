using System;
using System.Linq;

public class SequenceOfCommands_broken
{
    private const char ArgumentsDelimiter = ' ';

    public static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());

        long[] array = Console.ReadLine()
            .Split(ArgumentsDelimiter)
            .Select(long.Parse)
            .ToArray();

        string[] command = Console.ReadLine().ToLower().Split(ArgumentsDelimiter).ToArray();

        while (!command[0].Equals("stop"))
        {
            int[] args = new int[2];
            if (command.Length > 1)
            {
                args[0] = int.Parse(command[1]);
                args[1] = int.Parse(command[2]);
            }
            
            PerformAction(array, command[0], args);
            PrintArray(array);

            command = Console.ReadLine().ToLower().Split(ArgumentsDelimiter).ToArray();
        }
    }

    static void PerformAction(long[] arr, string action, int[] args)
    {
        int pos = args[0];
        int value = args[1];

        switch (action)
        {
            case "multiply":
                arr[pos - 1] *= value;
                break;
            case "add":
                arr[pos - 1] += value;
                break;
            case "subtract":
                arr[pos - 1] -= value;
                break;
            case "lshift":
                ArrayShiftLeft(arr);
                break;
            case "rshift":
                ArrayShiftRight(arr);
                break;
        }
    }

    private static void ArrayShiftRight(long[] array)
    {
        var lastElement = array[array.Length - 1];
        for (int i = array.Length - 1; i >= 1; i--)
        {
            array[i] = array[i - 1];
        }
        array[0] = lastElement;
    }

    private static void ArrayShiftLeft(long[] array)
    {
        var firstElement = array[0];
        for (int i = 0; i < array.Length - 1; i++)
        {
            array[i] = array[i + 1];
        }
        array[array.Length - 1] = firstElement;
    }

    private static void PrintArray(long[] array)
    {
        Console.WriteLine(string.Join(" ", array));
    }
}
