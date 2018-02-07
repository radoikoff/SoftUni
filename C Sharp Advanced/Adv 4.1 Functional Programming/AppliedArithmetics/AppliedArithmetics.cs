using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string command = Console.ReadLine().Trim().ToLower();

            Func<int, int> add = input => input + 1;
            Func<int, int> mulitiply = input => input * 2;
            Func<int, int> substract = input => input - 1;

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(add).ToArray();
                        break;

                    case "multiply":
                        numbers = numbers.Select(mulitiply).ToArray();
                        break;
                        
                    case "subtract":
                        numbers = numbers.Select(substract).ToArray();
                        break;

                    case "print":
                        Console.WriteLine(string.Join(" ",numbers));
                        break;
                }



                command = Console.ReadLine().Trim().ToLower();
            }

        }
    }
}
