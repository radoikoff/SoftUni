using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Maximum_Element
{
    public class MaxElement
    {
        public static void Main()
        {
            var queryCount = long.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxValue = int.MinValue;
            var maxNumbers = new Stack<int>();

            for (long i = 0; i < queryCount; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                switch (input[0])
                {
                    case 1:
                        stack.Push(input[1]);
                        if (maxValue < input[1])
                        {
                            maxValue = input[1];
                            maxNumbers.Push(maxValue);
                        }
                        break;
                    case 2:
                        if (stack.Count != 0)
                        {
                            if (stack.Pop() == maxValue)
                            {
                                maxNumbers.Pop();
                                if (maxNumbers.Count != 0)
                                {
                                    maxValue = maxNumbers.Peek();
                                }
                                else
                                {
                                    maxValue = int.MinValue;
                                }
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxValue);
                        break;
                }
            }
        }
    }
}
