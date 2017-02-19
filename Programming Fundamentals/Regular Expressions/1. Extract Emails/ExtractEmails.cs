using System;
using System.Text.RegularExpressions;


namespace _1.Extract_Emails
{
    public class ExtractEmails
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            string pattern = @"[A-Za-z0-9_.-]+@[A-Za-z-]+\.[A-Za-z-]+\.*[A-Za-z-]+";
            Regex regex = new Regex(pattern);
            
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                if (!match.Value.StartsWith("-") && !match.Value.StartsWith(".") && !match.Value.StartsWith("_")
                    && !match.Value.EndsWith("-") && !match.Value.EndsWith(".") && !match.Value.EndsWith("_"))
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
