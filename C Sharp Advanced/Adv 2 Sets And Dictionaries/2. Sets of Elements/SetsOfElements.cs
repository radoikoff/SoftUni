using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Sets_of_Elements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            var setLenght = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < setLenght[0]; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (!firstSet.Contains(input))
                {
                    firstSet.Add(input);
                }
            }

            for (int i = 0; i < setLenght[1]; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (!secondSet.Contains(input))
                {
                    secondSet.Add(input);
                }
            }
            var result = new HashSet<int>();
            if (firstSet.Count >= secondSet.Count)
            {
                GetResult(secondSet, firstSet, result);
            }
            else
            {
                GetResult(firstSet, secondSet, result);
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static void GetResult(HashSet<int> source, HashSet<int> target, HashSet<int> result)
        {
            foreach (var item in source)
            {
                if (target.Contains(item))
                {
                    result.Add(item);
                }
            }
        }
    }
}
