using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rubiks_Matrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            var RubikDim = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = RubikDim[0];
            var cols = RubikDim[1];

            int[,] rubik = new int[rows, cols];

            //fill data
            int counter = 1;
            for (int i = 0; i < RubikDim[0]; i++)
            {
                for (int j = 0; j < RubikDim[1]; j++)
                {
                    rubik[i, j] = counter;
                    counter++;
                }
            }

            //execute commands
            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandElements = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var rcIndex = int.Parse(commandElements[0]);
                var command = commandElements[1];
                var moves = int.Parse(commandElements[2]);

                //var buffer = new Queue<int>();
                //int rubikLength = 0;

                switch (command)
                {
                    case "up":
                        MoveCol(rubik, rcIndex, moves % rows);
                        break;
                    case "down":
                        MoveCol(rubik, rcIndex, rows - moves % rows);
                        break;
                    case "left":
                        MoveRow(rubik, rcIndex, moves % cols);
                        break;
                    case "right":
                        MoveRow(rubik, rcIndex, cols - moves % cols);
                        break;
                }
            }

            //rearange
            var element = 1;
            for (int rowIndex = 0; rowIndex < rubik.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < rubik.GetLength(1); colIndex++)
                {
                    if (rubik[rowIndex, colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < rubik.GetLength(0); r++)
                        {
                            for (int c = 0; c < rubik.GetLength(1); c++)
                            {
                                if (rubik[r, c] == element)
                                {
                                    var ElementToSwap = rubik[rowIndex, colIndex];
                                    rubik[rowIndex, colIndex] = element;
                                    rubik[r, c] = ElementToSwap;
                                    Console.WriteLine($"Swap ({rowIndex }, {colIndex }) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }

        }

        private static void MoveRow(int[,] rubik, int rcIndex, int moves)
        {
            //moves = moves % rubik.GetLength(0);
            var temp = new int[rubik.GetLength(1)];
            for (int colIndex = 0; colIndex < rubik.GetLength(0); colIndex++)
            {
                temp[colIndex] = rubik[rcIndex, (colIndex + moves) % rubik.GetLength(1)];
            }

            for (int colIndex = 0; colIndex < rubik.GetLength(1); colIndex++)
            {
                rubik[rcIndex, colIndex] = temp[colIndex];
            }
        }

        private static void MoveCol(int[,] rubik, int rcIndex, int moves)
        {
            //moves = moves % rubik.GetLength(0);
            var temp = new int[rubik.GetLength(0)];
            for (int rowIndex = 0; rowIndex < rubik.GetLength(0); rowIndex++)
            {
                temp[rowIndex] = rubik[(rowIndex + moves) % rubik.GetLength(0), rcIndex];
            }

            for (int rowIndex = 0; rowIndex < rubik.GetLength(0); rowIndex++)
            {
                rubik[rowIndex, rcIndex] = temp[rowIndex];
            }
        }
    }
}

