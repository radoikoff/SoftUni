using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Formatting_Numbers
{
    public class FormattingNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            int numOne = int.Parse(input[0]);
            double numTwo = double.Parse(input[1]);
            double numThree = double.Parse(input[2]);


            string numOneInBinary = Convert.ToString(numOne, 2);
            string result = "";
            if (numOneInBinary.Length >= 10)
            {
                result = numOneInBinary.Substring(0, 10);
            }
            else
            {
                result = numOneInBinary.PadLeft(10, '0');
            }
            Console.WriteLine("|{0,-10:X}|{1,10}|{2,10:f2}|{3,-10:f3}|", numOne, result, numTwo, numThree);
        }
    }
}
