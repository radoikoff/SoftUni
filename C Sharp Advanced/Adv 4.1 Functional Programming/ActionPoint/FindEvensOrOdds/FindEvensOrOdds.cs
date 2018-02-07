using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main()
        {
            Predicate<int> isEven = input => input % 2 == 0;

            var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var startNumber = numbers[0];
            var endNumber = numbers[1];
            var command = Console.ReadLine().Trim();
            var result = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (command == "even")
                {
                    if (i % 2 == 0)
                    {
                        result.Add(i);
                    }
                }
                else if (command == "odd")
                {
                    if (i % 2 != 0)
                    {
                        result.Add(i);
                    }
                }


            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
