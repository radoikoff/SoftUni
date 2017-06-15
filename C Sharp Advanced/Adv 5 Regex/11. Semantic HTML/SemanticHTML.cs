using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.Semantic_HTML
{
    public class SemanticHTML
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            Regex openDivRegex = new Regex(@"(<div).+((id|class)\s*=\s*""(.+?)"")");
            Regex closeDivRegex = new Regex(@"<\/(div)>\s*(<!--\s*([a-z]+)\s*-->)");

            while (input != "END")
            {
                string result = "";
                Match match = openDivRegex.Match(input);
                if (match.Success)
                {
                    string divTagName = match.Groups[1].Value;
                    string idOrClassSection = match.Groups[2].Value;
                    string semanticTagName = match.Groups[4].Value;

                    if (IsTagValid(semanticTagName))
                    {
                        result = input.Replace(divTagName, "<" + semanticTagName);
                        result = result.Replace(idOrClassSection, null);
                        result = DoSpaceFixing(result);
                    }
                }
                else if (closeDivRegex.IsMatch(input))
                {
                    match = closeDivRegex.Match(input);

                    string divTagName = match.Groups[1].Value;
                    string htmlCommnent = match.Groups[2].Value;
                    string semanticTagName = match.Groups[3].Value;

                    if (IsTagValid(semanticTagName))
                    {
                        result = input.Replace(divTagName, semanticTagName);
                        result = result.Replace(htmlCommnent, null);
                    }
                }
                else
                {
                    result = input;
                }

                Console.WriteLine(result);

                input = Console.ReadLine();
            }


        }

        private static string DoSpaceFixing(string input)
        {
            Regex fixSpaces = new Regex(@"\s{2,}");
            int leadingSpaces = 0;

            foreach (Match match in fixSpaces.Matches(input))
            {
                if (match.Index == 0)
                {
                    leadingSpaces = match.Length;
                    break;
                }
            }

            input = fixSpaces.Replace(input, " ");
            input = new string(' ', leadingSpaces) + input.TrimStart();

            fixSpaces = new Regex("\\s+(?=>)");
            input = fixSpaces.Replace(input, "");

            return input;
        }

        private static bool IsTagValid(string tag)
        {
            switch (tag)
            {
                case "main":
                case "header":
                case "nav":
                case "article":
                case "section":
                case "aside":
                case "footer":
                    return true;
            }
            return false;
        }
    }
}