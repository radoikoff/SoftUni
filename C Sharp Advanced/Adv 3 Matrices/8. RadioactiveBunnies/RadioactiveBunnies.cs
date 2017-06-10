using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.RadioactiveBunnies
{
    public class RadioactiveBunnies
    {
        public static void Main()
        {
            var lairDim = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = lairDim[0];
            var cols = lairDim[1];

            char[][] lair = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                lair[i] = Console.ReadLine().ToCharArray();
            }

            string commands = Console.ReadLine();

            //initial palyer position
            int playerRow = -1;
            int playerCol = -1;
            for (int i = 0; i < rows; i++)
            {
                playerCol = Array.IndexOf(lair[i], 'P');
                if (playerCol >= 0)
                {
                    playerRow = i;
                    break;
                }
            }

            string playerState = "";
            for (int move = 0; move < commands.Length; move++)
            {
                //update player pos
                var direction = commands[move];
                switch (direction)
                {
                    case 'U':
                        lair[playerRow][playerCol] = '.';

                        if (playerRow - 1 >= 0)
                        {
                            playerRow--;
                            lair[playerRow][playerCol] = 'P';
                        }
                        else
                        {
                            playerState = "won";
                        }
                        break;

                    case 'D':
                        lair[playerRow][playerCol] = '.';

                        if (playerRow + 1 < rows)
                        {
                            playerRow++;
                            lair[playerRow][playerCol] = 'P';
                        }
                        else
                        {
                            playerState = "won";
                        }
                        break;

                    case 'L':
                        lair[playerRow][playerCol] = '.';

                        if (playerCol - 1 >= 0)
                        {
                            playerCol--;
                            lair[playerRow][playerCol] = 'P';
                        }
                        else
                        {
                            playerState = "won";
                        }
                        break;

                    case 'R':
                        lair[playerRow][playerCol] = '.';

                        if (playerCol + 1 < cols)
                        {
                            playerCol++;
                            lair[playerRow][playerCol] = 'P';
                        }
                        else
                        {
                            playerState = "won";
                        }
                        break;
                }



                //update bunnies pos
                var bunniesRow = new List<int>();
                var bunniesCol = new List<int>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (lair[row][col] == 'B')
                        {
                            bunniesRow.Add(row);
                            bunniesCol.Add(col);
                        }
                    }
                }

                for (int i = 0; i < bunniesRow.Count; i++)
                {
                    if (bunniesRow[i] - 1 >= 0) lair[bunniesRow[i] - 1][bunniesCol[i]] = 'B';
                    if (bunniesRow[i] + 1 < rows) lair[bunniesRow[i] + 1][bunniesCol[i]] = 'B';
                    if (bunniesCol[i] - 1 >= 0) lair[bunniesRow[i]][bunniesCol[i] - 1] = 'B';
                    if (bunniesCol[i] + 1 < cols) lair[bunniesRow[i]][bunniesCol[i] + 1] = 'B';
                }


                if (playerState == "won")
                {
                    break;
                }

                //check if colide
                if (lair[playerRow][playerCol] == 'B')
                {
                    playerState = "dead";
                    break;
                }
            }

            //result
            for (int r = 0; r < rows; r++)
            {
                Console.WriteLine(string.Join("", lair[r]));
            }
            Console.WriteLine($"{playerState}: {playerRow} {playerCol}");
        }
    }
}
