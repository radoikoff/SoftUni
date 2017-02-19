using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _4.Query_Mess
{
    public class QueryMess
    {
        public static void Main()
        {
            var data = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "END")
            {
                string trimInput = FixSpaces(input);
                string[] pairs = trimInput.Split('&');
                foreach (var pair in pairs)
                {
                    string[] tokens = pair.Split('=');
                    string key = tokens[0].Trim();
                    string value = tokens[1].Trim();

                    if (key.Contains("?"))
                    {
                        key = key.Substring(key.IndexOf("?")+1);
                    }

                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, new List<string>());
                    }
                    data[key].Add(value);
                }
                //print data
                foreach (var item in data)
                {
                    Console.Write($"{item.Key}=[{string.Join(", ", item.Value)}]");
                }
                Console.WriteLine();
                data.Clear();
                input = Console.ReadLine();
            }
        }

        private static string FixSpaces(string input)
        {
            string pattern = @"(%20|\+)+";
            Regex regex = new Regex(pattern);
            string fixedString = regex.Replace(input, " ");
            return fixedString;
        }
    }
}
