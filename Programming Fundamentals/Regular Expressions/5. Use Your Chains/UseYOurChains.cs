using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _5.Use_Your_Chains
{
    public class UseYourChains
    {
        public static void Main()
        {
            var final = new List<string>();
            string input = Console.ReadLine();

            string pattern = @"<p>.+?<\/p>"; 
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                string trimmedMatch = match.ToString().Remove(0, 3).Remove(match.Length - 7);

                pattern = @"[^a-z0-9]";
                regex = new Regex(pattern);
                string result = regex.Replace(trimmedMatch, " ");
                string decodedResult = DecodeText(result);

                pattern = @"\s+";
                regex = new Regex(pattern);
                var decodedResultsTrim = regex.Replace(decodedResult, " ");

                final.Add(decodedResultsTrim); 
            }

            Console.WriteLine(string.Join(null, final));
        }


        public static string DecodeText(string text)
        {
            var textArr = text.ToCharArray();
            for (int i = 0; i < textArr.Length; i++)
            {
                if (textArr[i] >= 97 && textArr[i] <= 109)
                {
                    textArr[i] = (char)(textArr[i] + 13);
                    continue;
                }
                if (textArr[i] >= 110 && textArr[i] <= 122)
                {
                    textArr[i] = (char)(textArr[i] - 13);
                }
            }
            return string.Join(null, textArr);
        }
    }
}

