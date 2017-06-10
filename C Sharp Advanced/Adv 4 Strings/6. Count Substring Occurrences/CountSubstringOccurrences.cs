using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Count_Substring_Occurrences
{
    public class CountSubstringOccurrences
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();
            int count = 0;
            int index = -1;

            index = text.IndexOf(pattern);
            while (index != -1)
            {
                text = text.Substring(index + 1);
                count++;
                index = text.IndexOf(pattern);
            }

            Console.WriteLine(count);
        }
    }
}
