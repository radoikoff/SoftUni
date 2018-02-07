using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main()
        {

            var names = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> nameWriter = (name) => Console.WriteLine(name);

            foreach (var name in names)
            {
                nameWriter(name);
            }
        }
    }
}

