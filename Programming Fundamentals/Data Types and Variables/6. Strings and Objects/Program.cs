using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstItem = "Hello";
            string secondItem = "World";
            object result = firstItem + ' ' + secondItem;
            Console.WriteLine(result.ToString());

        }
    }
}
