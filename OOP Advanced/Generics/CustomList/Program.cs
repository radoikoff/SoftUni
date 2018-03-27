using System;

namespace CustomList
{
    class Program
    {
        static void Main()
        {
            CustomList<string> data = new CustomList<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var args = input.Split();
                string command = args[0];
                string element = "";
                //string result = string.Empty;

                switch (command)
                {
                    case "Add":
                        element = args[1];
                        data.Add(element);
                        break;
                    case "Remove":
                        element = args[1];
                        data.Remove(int.Parse(element));
                        break;
                    case "Contains":
                        element = args[1];
                        Console.WriteLine(data.Contains(element).ToString());
                        break;
                    case "Swap":
                        string elementOne = args[1];
                        string elementTwo = args[2];
                        data.Swap(int.Parse(elementOne), int.Parse(elementTwo));
                        break;
                    case "Greater":
                        element = args[1];
                        Console.WriteLine(data.CountGreaterThan(element).ToString());
                        break;
                    case "Max":
                        Console.WriteLine(data.Max().ToString());
                        break;
                    case "Min":
                        Console.WriteLine(data.Min().ToString());
                        break;
                    case "Print":
                        foreach (var item in data.Items)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                }
            }
        }
    }
}