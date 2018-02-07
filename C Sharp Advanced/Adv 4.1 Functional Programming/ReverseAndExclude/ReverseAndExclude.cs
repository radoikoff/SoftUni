using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var divisor = int.Parse(Console.ReadLine());

            var result = numbers.Where(n => n % divisor != 0).Reverse().ToArray();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
