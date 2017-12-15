using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.Little_John
{
    public class LittleJohn
    {
        public static void Main()
        {
            var regex = new Regex(@"(>>>-{5}>>)|(>>-{5}>)|(>-{5}>)");
            int smallArrow = 0;
            int mediumArrow = 0;
            int bigArrow = 0;
            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();

                foreach (Match match in regex.Matches(input))
                {
                    if (match.Groups[1].Success)
                    {
                        bigArrow++;
                    }

                    if (match.Groups[2].Success)
                    {
                        mediumArrow++;
                    }

                    if (match.Groups[3].Success)
                    {
                        smallArrow++;
                    }

                }
            }
            string numberinDec = string.Concat(smallArrow, mediumArrow, bigArrow);
            string numberInBin = Convert.ToString(int.Parse(numberinDec), 2);
            var reversed = string.Join(null, numberInBin.Reverse());
            int result = Convert.ToInt32(numberInBin + reversed, 2);

            Console.WriteLine(result);
        }
    }
}
