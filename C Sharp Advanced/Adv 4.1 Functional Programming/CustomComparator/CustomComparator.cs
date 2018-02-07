using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main()
        { 
            var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var result = numbers.OrderByDescending(x => x % 2 == 0).ThenBy(x => x).ToArray();

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
