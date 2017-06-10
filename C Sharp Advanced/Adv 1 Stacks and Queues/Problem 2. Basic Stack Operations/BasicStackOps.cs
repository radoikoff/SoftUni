using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Basic_Stack_Operations
{
    public class BasicStackOps
    {
        public static void Main()
        {
            var command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var data = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();

            for (int i = 0; i < command[0]; i++)
            {
                stack.Push(data[i]);
            }

            for (int i = 0; i < command[1]; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                stack.Pop();
            }

            if (stack.Contains(command[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count != 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
