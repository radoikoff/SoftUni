using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Numbers
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToArray();

            var stack = new Stack<string>();

            foreach (var number in input)
            {
                stack.Push(number);
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}

