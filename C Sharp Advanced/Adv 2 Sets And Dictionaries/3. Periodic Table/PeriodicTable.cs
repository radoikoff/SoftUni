using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Periodic_Table
{
    public class PeriodicTable
    {
        public static void Main()
        {
            var elements = new HashSet<string>();
            var number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var compound = Console.ReadLine().Split();
                foreach (var element in compound)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(e => e)));
        }
    }
}
