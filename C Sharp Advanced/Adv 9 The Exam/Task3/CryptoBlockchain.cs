using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main()
        {
            var cryptoBlock = String.Empty;

            var numberOfLines = int.Parse(Console.ReadLine());
            for (int line = 0; line < numberOfLines; line++)
            {
                cryptoBlock += Console.ReadLine();
            }

            //string pattern = @"({.*?(\d{3,}).*?})|(\[.*?(\d{3,}).*?\])";
            string pattern = @"({|\[).*?(\d{3,}).*?(}|\])";
            var result = new List<char>();

            var regex = new Regex(pattern);
            if (regex.IsMatch(cryptoBlock))
            {
                var matches = regex.Matches(cryptoBlock);
                foreach (Match match in matches)
                {
                    bool optionOne = match.Value.StartsWith("[") && match.Value.EndsWith("]");
                    bool optionTwo = match.Value.StartsWith("{") && match.Value.EndsWith("}");
                    if (optionOne || optionTwo)
                    {
                        var group = match.Groups[2];
                        if (group.Length % 3 == 0) //group is valid 
                        {
                            for (int counter = 0; counter < group.Length / 3; counter++)
                            {
                                string numberAsString = string.Join("", group.Value.Skip(counter * 3).Take(3));
                                int number = int.Parse(numberAsString) - match.Length;
                                result.Add(Convert.ToChar(number));
                            }
                        }

                    }

                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}
