using System;

namespace CountMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new Box<double>();

            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = double.Parse(Console.ReadLine());
                box.Elements.Add(input);
            }

            var compareToValue = double.Parse(Console.ReadLine());

            Console.WriteLine(box.EqualsCount(compareToValue));
        }

    }
}
