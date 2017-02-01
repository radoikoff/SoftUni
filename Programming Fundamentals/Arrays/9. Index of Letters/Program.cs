using System;

namespace _9.Index_of_Letters
{
    class Program
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            foreach (var item in text)
            {
                Console.WriteLine($"{item} -> {item - 'a'}");
            }
        }
    }
}
