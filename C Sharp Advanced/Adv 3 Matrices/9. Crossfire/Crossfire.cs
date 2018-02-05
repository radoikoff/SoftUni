using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            var matrixDimentions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrixRowsCount = matrixDimentions[0];
            var matrixColsCount = matrixDimentions[1];

            var matrix = new int[matrixRowsCount][];
            FillTheMatrix(matrix, matrixRowsCount, matrixColsCount);

            string input = Console.ReadLine().Trim();

            while (input != "Nuke it from orbit")
            {
                var shootParam = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var impactRow = shootParam[0];
                var impactCol = shootParam[1];
                var blastRadius = shootParam[2];

                //set zero for dead cells on thr row
                for (int counterCol = Math.Max(0, impactCol - blastRadius); counterCol < Math.Min(matrix[impactRow].Length, impactCol + blastRadius); counterCol++)
                {
                    matrix[impactRow][counterCol] = 0;
                }

                for (int counterRow = Math.Max(0, impactRow - blastRadius); counterRow < Math.Min(matrixRowsCount, impactRow + blastRadius); counterRow++)
                {
                    if (impactCol >= 0 && impactCol < matrix[counterRow].Length)
                    {
                        matrix[counterRow][impactCol] = 0;
                    }

                }

                for (int counterRow = 0; counterRow < matrixRowsCount; counterRow++)
                {
                    matrix[counterRow] = matrix[counterRow].Where(d => d != 0).ToArray();
                }

                input = Console.ReadLine().Trim();
            }

            //print result
            for (int i = 0; i < matrixRowsCount; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }







        }

        private static void FillTheMatrix(int[][] matrix, int rows, int cols)
        {
            int counter = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }
            }
        }
    }

}
