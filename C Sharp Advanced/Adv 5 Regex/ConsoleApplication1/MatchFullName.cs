using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    public class MatchFullName
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            Regex regex = new Regex(@"\b[A-Z][a-z]{1,}[ ][A-Z][a-z]{1,}\b");
            while (name != "end")
            {
                Match match = regex.Match(name);
                if (match.Success)
                {
                    Console.WriteLine(match);
                }


                name = Console.ReadLine();
            }
        }
    }
}
