using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sneaking
{
    class Sneaking
    {
        static void Main()
        {
            var roomSize = int.Parse(Console.ReadLine());

            char[][] room = new char[roomSize][];

            for (int row = 0; row < roomSize; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
            }

            var commands = Console.ReadLine().ToCharArray();

            //initial positions
            int samCurrentRow = 0;
            int samCurrentCol = 0;
            int nikoCurrentRow = 0;
            int nikoCurrentCol = 0;
            for (int row = 0; row < room.Length; row++)
            {
                if (room[row].Contains('S'))
                {
                    samCurrentRow = row;
                    samCurrentCol = Array.IndexOf(room[row], 'S');
                }
                if (room[row].Contains('N'))
                {
                    nikoCurrentRow = row;
                    nikoCurrentCol = Array.IndexOf(room[row], 'N');
                }
            }


            for (int move = 0; move < commands.Length; move++)
            {
                var samCommand = commands[move];

                EnemyMove(room);
                if (IsSamKilled(room, samCurrentRow, samCurrentCol))
                {
                    Console.WriteLine($"Sam died at {samCurrentRow}, {samCurrentCol}");
                    PrintCuurentRoomState(room);
                    break;
                }

                //sam moves
                switch (samCommand)
                {
                    case 'U':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow - 1][samCurrentCol] = 'S';
                        samCurrentRow--;
                        break;
                    case 'D':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow + 1][samCurrentCol] = 'S';
                        samCurrentRow++;
                        break;
                    case 'L':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow][samCurrentCol - 1] = 'S';
                        samCurrentCol--;
                        break;
                    case 'R':
                        room[samCurrentRow][samCurrentCol] = '.';
                        room[samCurrentRow][samCurrentCol + 1] = 'S';
                        samCurrentCol++;
                        break;
                }

                //check if sam kills
                if (samCurrentRow == nikoCurrentRow)
                {
                    Console.WriteLine($"Nikoladze killed!");
                    room[nikoCurrentRow][nikoCurrentCol] = 'X';
                    PrintCuurentRoomState(room);
                    break;
                }
            }

        }

        private static void PrintCuurentRoomState(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                Console.WriteLine(string.Join("", room[row]));
            }
        }

        private static bool IsSamKilled(char[][] room, int samCurrentRow, int samCurrentCol)
        {
            bool isKilled = false;
            if (room[samCurrentRow].Contains('b'))
            {
                var enemyCol = Array.IndexOf(room[samCurrentRow], 'b');
                if (samCurrentCol >= enemyCol)
                {
                    room[samCurrentRow][samCurrentCol] = 'X';
                    isKilled = true;
                }
            }
            else if (room[samCurrentRow].Contains('d'))
            {
                var enemyCol = Array.IndexOf(room[samCurrentRow], 'd');
                if (samCurrentCol <= enemyCol)
                {
                    room[samCurrentRow][samCurrentCol] = 'X';
                    isKilled = true;
                }
            }

            return isKilled;
        }

        private static void EnemyMove(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    var currentValue = room[row][col];

                    if (currentValue == 'b')
                    {
                        if (col < room[row].Length - 1)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                        break;
                    }
                    else if (currentValue == 'd')
                    {
                        if (col > 0)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                        break;
                    }
                }
            }
        }



    }
}
