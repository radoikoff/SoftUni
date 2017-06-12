using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.Match_Phone_Number
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var name = Console.ReadLine();
            Regex regex = new Regex(@"\+359( |-)\d(\1)\d{3}(\1)\d{4}\b");
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
