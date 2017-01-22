using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string hexOutput = Convert.ToString(input, 16).ToUpper();
            string binOutput = Convert.ToString(input, 2);

            Console.WriteLine(hexOutput);
            Console.WriteLine(binOutput);
        }
    }
}
