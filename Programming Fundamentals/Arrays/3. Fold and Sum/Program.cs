using System;
using System.Linq;


namespace _3.Fold_and_Sum
{
    public class Program
    {
        static void Main()
        {
            var source = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = source.Length / 4;
            var firstRowArray = new int[source.Length / 2];
            var SecondRowArray = new int[source.Length / 2];

            for (int i = 0; i < k; i++) //left side
            {
                firstRowArray[i] = source[k - 1 - i];
            }

            int sourceIndex = source.Length - 1;    //right side
            for (int i = k; i < 2 * k; i++) 
            {
                firstRowArray[i] = source[sourceIndex];
                sourceIndex--;
            }
            //Console.WriteLine(string.Join(" ", firstRowArray));

            for (int i = 0; i < 2*k; i++)
            {
                SecondRowArray[i] = source[k+i];
            }
            //Console.WriteLine(string.Join(" ", SecondRowArray));

            for (int i = 0; i < 2*k; i++)
            {
                SecondRowArray[i] += firstRowArray[i];
            }
            Console.WriteLine(string.Join(" ", SecondRowArray));
        }
    }
}
