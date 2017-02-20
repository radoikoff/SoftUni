using System;

namespace _4.Character_Multiplier
{
    public class CharacterMultiplier
    {
        public static void Main()
        {
            string[] tokens = Console.ReadLine().Split();
            string first = tokens[0];
            string second = tokens[1];

            int delta = Math.Abs(first.Length - second.Length);
            if (first.Length > second.Length)
            {
                second += new string('\0', delta);
            }
            else
            {
                first += new string('\0', delta);
            }

            long result = 0;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] !='\0' && second[i]!='\0')
                {
                    result += first[i] * second[i];
                }
                else
                {
                    result += first[i] + second[i];
                }
            }

            Console.WriteLine(result);
        }
    }
}
