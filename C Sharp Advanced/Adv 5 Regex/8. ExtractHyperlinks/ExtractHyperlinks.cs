using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8.ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();

            while (input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            Regex regex = new Regex(@"<a\s(.+?)>");
            var matches = regex.Matches(sb.ToString());

            foreach (Match match in matches)
            {
                string aTag = match.Groups[1].Value;

                //extract href

                var hrefRegexOne = new Regex(@"href\s*=\s*(""|')(.+?)(\1)");
                var hrefRegexTwo = new Regex(@"href\s*=\s*(.+?)\s");
                string href = "";

                if (hrefRegexOne.IsMatch(aTag))
                {
                    href = hrefRegexOne.Match(aTag).Groups[2].Value;
                }
                else if (hrefRegexTwo.IsMatch(aTag + " "))
                {
                    href = hrefRegexTwo.Match(aTag + " ").Groups[1].Value;  //to trim
                }

                if (href != "")
                {
                    Console.WriteLine(href);
                }
            }
        }
    }
}
