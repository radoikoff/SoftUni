using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Matrix_of_Palindromes
{
    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = input[0];
            int col = input[1];

            var letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var matrix = new string[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    char midLetter;
                    if (i + j < 26)
                    {
                        midLetter = letters[i + j];
                    }
                    else
                    {
                        midLetter = letters[i + j - 26];
                    }

                    matrix[i, j] = new string(new char[] { letters[i], midLetter, letters[i] });
                }
            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
