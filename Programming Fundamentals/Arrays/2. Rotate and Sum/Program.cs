using System;
using System.Linq;


namespace _2.Rotate_and_Sum
{
    class Program
    {
        static void Main()
        {
            var source = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int timesToRotate = int.Parse(Console.ReadLine());

            int arrLength = source.Length;
            var target = new int[arrLength];
            var sum = new int[arrLength];

            for (int rotate = 1; rotate <= timesToRotate; rotate++)
            {

                for (int i = 0; i < arrLength; i++)
                {
                    target[(i + 1) % arrLength] = source[i];
                }

                for (int i = 0; i < arrLength; i++)
                {
                    sum[i] += target[i];
                }
                //Console.WriteLine(string.Join(" ", target));

                for (int i = 0; i < arrLength; i++)
                {
                    source[i] = target[i];
                }
            }
            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
