using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Reverse_Strings
{
    public class ReverseStrings
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(new string(arr));
        }
    }
}
