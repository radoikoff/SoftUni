using System;
using System.Linq;


namespace _1.Largest_Common_End
{
    class Program
    {
        static void Main()
        {
            string[] inputOne = Console.ReadLine().Split(' ').ToArray();
            string[] inputTwo = Console.ReadLine().Split(' ').ToArray();
           
                        int hitCountLeft = HitCount(inputOne, inputTwo);
            var InputOneReversed = inputOne.Reverse().ToArray();
            var InputTwoReversed = inputTwo.Reverse().ToArray();
            int hitCountRight = HitCount(InputOneReversed, InputTwoReversed);

            Console.WriteLine(Math.Max(hitCountLeft, hitCountRight));
        }

        public static int HitCount (string[] input1, string[] input2)
        {
            int shortherLenght = Math.Min(input1.Length, input2.Length);
            int hitCounter = 0;
            for (int i = 0; i < shortherLenght; i++)
            {
                if (input1[i] == input2[i])
                {
                    hitCounter++;
                }
            }
            return hitCounter;
        }
    }
}
