using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemOne
{
    public class Regeh
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";
            var regex = new Regex(pattern);

            int index = 0;
            string result = string.Empty;

            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                for (int i = 1; i <= 2; i++)
                {
                    index += int.Parse(match.Groups[i].Value);

                    while (index > input.Length - 1)
                    {
                        index -= input.Length - 1;
                    }

                    result += input[index];
                }
            }

            Console.WriteLine(result);



        }
    }
}
