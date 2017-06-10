using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Lego_Blocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cellNumber = 0;

            int[][] firstArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                firstArray[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                cellNumber += firstArray[i].Length;
            }

            int[][] secondArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                secondArray[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToArray();
                cellNumber += secondArray[i].Length;
            }

            var resultRowLength = new HashSet<int>();
            for (int i = 0; i < rows; i++)
            {
                resultRowLength.Add(firstArray[i].Length + secondArray[i].Length);
            }

            if (resultRowLength.Count == 1)
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstArray[i])}, {string.Join(", ", secondArray[i])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {cellNumber}");
            }
        }
    }
}
