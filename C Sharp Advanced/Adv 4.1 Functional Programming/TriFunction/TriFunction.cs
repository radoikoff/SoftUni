using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriFunction
{
    class TriFunction
    {
        static void Main()
        {

            var limit = int.Parse(Console.ReadLine().Trim());
            if (limit < 0) return;

            var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var name = names.FirstOrDefault(n => check(n, limit));
            Console.WriteLine(name);
        }



        public static Func<string, int, bool> check = (string input, int limit) =>
        {
            int sum = input.ToCharArray().Sum(n=>n);
            if (sum >= limit)
            {
                return true;
            }
            return false;
        };
    }
    
}
