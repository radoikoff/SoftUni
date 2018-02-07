using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main()
        {
            var nameLenght = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var result = names.Where(n => n.Length <= nameLenght).ToArray();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
