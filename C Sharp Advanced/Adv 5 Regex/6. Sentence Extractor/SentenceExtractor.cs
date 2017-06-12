using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.Sentence_Extractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            string keyWord = Console.ReadLine();
            string inputText = Console.ReadLine();

            string pattern = @".+?(\.|!|\?)";
            Regex regex = new Regex(pattern);

            var sentences = regex.Matches(inputText);

            foreach (Match sentence in sentences)
            {
                pattern = "\\b" + keyWord.Trim() + "\\b";
                regex = new Regex(pattern);
                if (regex.IsMatch(sentence.Value))
                {
                    Console.WriteLine(sentence.Value);
                }

            }
        }
    }
}
