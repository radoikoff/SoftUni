using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemTwo
{
    public class KnightGame
    {
        public static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());
            var knights = new List<int>();

            var board = new char[boardSize][];
            for (int i = 0; i < boardSize; i++)
            {
                board[i] = Console.ReadLine().Trim().ToCharArray();
            }

            //int maxHits = 0;
            int iterations = 0;
            while (true)
            {
                int maxHits = 0;
                int rowToDel = 0;
                int colToDel = 0;
                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        if (board[row][col] == 'K')
                        {
                            var hits = CheckNumberOfKnightsUnderAttack(board, row, col);
                            knights.Add(hits);
                            //if (hits > maxHits)
                            //{
                            //    maxHits = hits;
                            //    rowToDel = row;
                            //    colToDel = col;
                            //}
                        }
                    }
                }

                if (maxHits == 0)
                {
                    break;
                }
                board[rowToDel][colToDel] = 'O';
                iterations++;


            }
            Console.WriteLine(iterations);



        }

        private static int CheckNumberOfKnightsUnderAttack(char[][] board, int row, int col)
        {
            int hits = 0;
            int boardSize = board.Length - 1;
            if (row - 1 >= 0 && col + 2 <= boardSize)
            {
                if (board[row - 1][col + 2] == 'K') hits++;
            }

            if (row - 2 >= 0 && col + 1 <= boardSize)
            {
                if (board[row - 2][col + 1] == 'K') hits++;
            }

            if (row - 1 >= 0 && col - 2 >= 0)
            {
                if (board[row - 1][col - 2] == 'K') hits++;
            }

            if (row - 2 >= 0 && col - 1 >= 0)
            {

                if (board[row - 2][col - 1] == 'K') hits++;
            }



            if (row + 1 <= boardSize && col + 2 <= boardSize)
            {
                if (board[row + 1][col + 2] == 'K') hits++;
            }

            if (row + 1 <= boardSize - 1 && col - 2 >= 0)
            {
                if (board[row + 1][col - 2] == 'K') hits++;
            }

            if (row + 2 <= boardSize && col + 1 <= boardSize)
            {
                if (board[row + 2][col + 1] == 'K') hits++;
            }


            if (row + 2 <= boardSize && col - 1 >= 0)
            {
                if (board[row + 2][col - 1] == 'K') hits++;
            }

            return hits;

        }
    }
}
