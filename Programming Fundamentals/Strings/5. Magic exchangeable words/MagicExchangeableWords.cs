using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Magic_exchangeable_words
{
    public class MagicExchangeableWords
    {
        public static void Main()
        {
            string[] tokens = Console.ReadLine().Split();

            if (IsWordExchanable(tokens[0], tokens[1]))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }

        }

        public static bool IsWordExchanable(string string1, string string2)
        {
            string first = null;
            string second = null;
            int maxLen = 0;
            int minLen = 0;
            var dict = new Dictionary<char, char>();

            if (string1.Length > string2.Length)
            {
                maxLen = string1.Length;
                minLen = string2.Length;
                first = string1;
                second = string2;
            }
            else
            {
                maxLen = string2.Length;
                minLen = string1.Length;
                first = string2;
                second = string1;
            }

            for (int i = 0; i < minLen; i++)
            {
                if (!dict.ContainsKey(first[i]))
                {
                    if (dict.ContainsValue(second[i]))
                    {
                        return false;
                    }
                    dict[first[i]] = second[i];
                }

                if (dict[first[i]] != second[i])
                {
                    return false;
                }
            }
            for (int i = minLen; i < maxLen; i++)
            {
                if (!dict.ContainsKey(first[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
