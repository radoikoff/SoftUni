using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.String_Length
{
    public class StrLength
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            if (text.Length <= 20)
            {
                Console.WriteLine(text + new string('*', 20 - text.Length));
            }
            else
            {
                Console.WriteLine(text.Substring(0, 20));
            }

        }
    }
}
