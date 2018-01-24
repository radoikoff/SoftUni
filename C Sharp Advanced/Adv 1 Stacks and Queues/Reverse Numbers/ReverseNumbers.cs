using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_Numbers
{
    public class ReverseNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions .RemoveEmptyEntries ).Select(int.Parse).ToArray();

            var stack = new Stack<int>();

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

