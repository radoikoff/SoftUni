using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> appendSir = (name) => Console.WriteLine("Sir" + ' '+ name);

            foreach (var name in names)
            {
                appendSir(name);
            }
        }
    }
}
