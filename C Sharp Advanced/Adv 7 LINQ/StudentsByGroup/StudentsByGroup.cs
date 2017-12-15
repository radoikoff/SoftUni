using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsByGroup
{
    class StudentsByGroup
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, string>();
            var input = Console.ReadLine();
            while (input != "END")
            {
                var tokens = input.Split();
                data.Add(tokens[0] + " " + tokens[1], tokens[2]);


                input = Console.ReadLine();
            }

            var result = data.Where(d => d.Value.Equals("2")).OrderBy(x => x.Key).ToList();
            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
