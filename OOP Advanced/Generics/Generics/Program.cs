using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string input = Console.ReadLine();
                var box = new Box<string>(input);

                Console.WriteLine($"{box.ToString()}: {box.Value}");
            }
        }
    }
}
