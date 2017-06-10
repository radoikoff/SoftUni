using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Target_Practice
{
    public class TargetPractice
    {
        public static void Main()
        {
            var matrixDimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixDimentions[0];
            var cols = matrixDimentions[1];

            string snake = Console.ReadLine();
            var shootParam = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var impactRow = shootParam[0];
            var impactCol = shootParam[1];
            var blastRadius = shootParam[2];

            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
            }

            //fill matrix
            int evenOddCounter = 1;
            int snakeIndex = 0;
            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                if (evenOddCounter % 2 == 0)
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        matrix[rowIndex][colIndex] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                else
                {
                    for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                    {
                        matrix[rowIndex][colIndex] = snake[snakeIndex];
                        snakeIndex++;
                        if (snakeIndex >= snake.Length)
                        {
                            snakeIndex = 0;
                        }
                    }
                }
                evenOddCounter++;
            }

            //shooting
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    if (isInsideBlastRadius(rowIndex, colIndex, impactRow, impactCol, blastRadius))
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }

            //falling
            for (int colIndex = 0; colIndex < cols; colIndex++)
            {
                var temp = new char[rows];
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {                    
                    temp[rowIndex] = matrix[rowIndex][colIndex];
                }
                temp = temp.Where(item => item != ' ').ToArray();
                var index = 0;
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    if (rowIndex < rows - temp.Length)
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                    else
                    {
                        matrix[rowIndex][colIndex] = temp[index];
                        index++;
                    }
                }
            }

            //result

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }


        }

        private static bool isInsideBlastRadius(int targetRow, int targetCol, int impactRow, int impactCol, int blastRadius)
        {
            var distanceToImpactPoint = Math.Sqrt((targetRow - impactRow) * (targetRow - impactRow) + (targetCol - impactCol) * (targetCol - impactCol));

            if (distanceToImpactPoint <= blastRadius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}