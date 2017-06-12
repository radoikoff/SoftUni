using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.ReplaceTag
{
    public class ReplaceTag
    {
        public static void Main()
        {
            var htmlText = Console.ReadLine();

            while (htmlText != "end")
            {
                Regex regex = new Regex(@"<a(.+?)>");
                var matches = regex.Matches(htmlText);

                foreach (Match match in matches)
                {
                    string href = match.Groups[1].Value;
                    string replaseStr = String.Format("[URL{0}]", href);
                    htmlText = regex.Replace(htmlText, replaseStr);
                }


                regex = new Regex(@"</a>");
                htmlText = regex.Replace(htmlText, "[/URL]");

                Console.WriteLine(htmlText);

                htmlText = Console.ReadLine();
            }

        }
    }
}
