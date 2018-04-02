using System;
using System.Linq;

namespace Stack
{
    public class Program
    {
        static void Main()
        {
            var cmdargs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string command = cmdargs[0];
            var stack = new Stack<int>();

            while (command != "END")
            {
                if (command == "Push")
                {
                    var args = cmdargs.Skip(1).ToList();
                    for (int i = 0; i < args.Count; i++)
                    {
                        stack.Push(int.Parse(args[i]));
                    }
                }
                else if (command == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }

                cmdargs = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                command = cmdargs[0];
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));

        }
    }
}
