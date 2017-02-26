using System;
using System.Text;

namespace _9.Melrah_Shake
{
    public class MelrahShake
    {
        public static void Main()
        {
            string target = Console.ReadLine();
            string pattern = Console.ReadLine();

            while (true)
            {
                if (target.IndexOf(pattern) != -1 && target.LastIndexOf(pattern) != -1
                    && pattern.Length > 0 && target.IndexOf(pattern) != target.LastIndexOf(pattern)
                    && pattern.Length * 2 <= target.Length)
                {
                    target = target.Remove(target.IndexOf(pattern), pattern.Length);
                    target = target.Remove(target.LastIndexOf(pattern), pattern.Length);
                    if (pattern.Length > 1)
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(target);
                    break;
                }
            }
        }
    }
}
