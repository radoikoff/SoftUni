using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split(new char[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            var palindromesList = new SortedSet<string>();

            foreach (var word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromesList.Add(word);
                }
            }

            Console.WriteLine("[" + string.Join(", ", palindromesList) + "]");

        }

        private static bool IsPalindrome(string word)
        {
            var reversedWord = new string(word.Reverse().ToArray());
            return word.Equals(reversedWord);
        }
    }
}
