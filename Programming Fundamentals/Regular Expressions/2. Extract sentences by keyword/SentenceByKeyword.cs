using System;
using System.Text.RegularExpressions;


namespace _2.Extract_sentences_by_keyword
{
    public class SentenceByKeyword
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            string[] input = Console.ReadLine().Split(new char[] { '.','!','?'});

            string pattern = "\\b" + word + "\\b";
            Regex regex = new Regex(pattern);

            foreach (var sentence in input)
            {
                if (regex.IsMatch(sentence))
                {
                    Console.WriteLine(sentence.Trim());
                }
            }

        }
    }
}
