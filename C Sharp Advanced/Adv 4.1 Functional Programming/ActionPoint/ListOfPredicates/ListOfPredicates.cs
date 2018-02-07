using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine().Trim());
            if (number < 0) return;

            var dividers = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var numbers = Enumerable.Range(1, number).Where(n => check(n, dividers)).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }



        public static Func<int, int[], bool> check = (int input, int[] dividers) =>
        {
            bool isDivisible = true;
            foreach (var divider in dividers)
            {
                if (input % divider != 0)
                {
                    isDivisible = false;
                    break;
                }
            }
            return isDivisible;
        };
    }
}


