using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Simple_Text_Editor
{
    public class SimpleTextEditor
    {
        public static void Main()
        {
            int opCount = int.Parse(Console.ReadLine());
            string text = string.Empty;
            var history = new Stack<string>();

            for (int i = 0; i < opCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var operation = int.Parse(tokens[0]);
                switch (operation)
                {
                    case 1:
                        history.Push(text);
                        text += tokens[1];
                        break;
                    case 2:
                        var argument = int.Parse(tokens[1]);
                        history.Push(text);
                        text = text.Remove(text.Length - argument);
                        break;
                    case 3:
                        var index = int.Parse(tokens[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        text = history.Pop();
                        break;
                }
            }
        }
    }
}
