using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Series_of_Letters
{
    public class SeriesOfLetters
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                Regex regex = new Regex(text[i] + "+");
                text = regex.Replace(text, text[i].ToString());
            }

            Console.WriteLine(text);
        }
    }
}
