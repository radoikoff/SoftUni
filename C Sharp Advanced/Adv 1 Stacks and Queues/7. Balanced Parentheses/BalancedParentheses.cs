using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Balanced_Parentheses
{
    public class BalancedParentheses
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            var data = new Stack<int>();
            bool fail = false;

            foreach (var symbol in input)
            {
                if (symbol.Equals('{') || symbol.Equals('[') || symbol.Equals('('))
                {
                    data.Push(GetCode(symbol));
                }
                else
                {
                    if (data.Count != 0 && data.Peek() == GetCode(symbol))
                    {
                        data.Pop();
                    }
                    else
                    {
                        fail = true;
                        break;
                    }
                }
            }

            if (data.Count == 0 && fail == false)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static int GetCode(char symbol)
        {
            if (symbol.Equals('{') || symbol.Equals('}'))
            {
                return 1;
            }
            else if (symbol.Equals('[') || symbol.Equals(']'))
            {
                return 2;
            }
            else if (symbol.Equals('(') || symbol.Equals(')'))
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}
