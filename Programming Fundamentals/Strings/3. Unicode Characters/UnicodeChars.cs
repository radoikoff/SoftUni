using System;

namespace _3.Unicode_Characters
{
    public class UnicodeChars
    {
        public static void Main()
        {
            char[] text = Console.ReadLine().ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                Console.Write($"\\u{(int)text[i]:x4}");
            }
        }
    }
}
