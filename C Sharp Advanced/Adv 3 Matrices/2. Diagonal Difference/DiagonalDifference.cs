using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Diagonal_Difference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());
            
            long leftDiag = 0;
            long rightDiag = 0;

            for (int i = 0; i < size; i++)
            {
                var rowInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                leftDiag += rowInput[i];
                rightDiag += rowInput[size - 1 - i];
            }

            Console.WriteLine(Math.Abs(leftDiag - rightDiag));

        }
    }
}
