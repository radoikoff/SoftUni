using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.String_Matrix_Rotation
{
    public class StringMatrixRotation
    {
        public static void Main()
        {
            var rotate = Console.ReadLine();
            int rotationAngle = int.Parse(rotate.Substring(rotate.IndexOf('(') + 1, rotate.IndexOf(')') - rotate.IndexOf('(') - 1));
            if (rotationAngle >= 360)
            {
                rotationAngle %= 360;
            }

            var matrix = new List<string>();
            int maxStrLength = 0;

            var data = Console.ReadLine();
            while (data != "END")
            {
                if (data.Length > maxStrLength)
                {
                    maxStrLength = data.Length;
                }
                matrix.Add(data);
                data = Console.ReadLine();
            }

            switch (rotationAngle)
            {
                case 0:
                    foreach (var row in matrix)
                    {
                        Console.WriteLine(row);
                    }
                    break;
                case 90:
                    break;
                case 180:
                    for (int i = matrix.Count-1; i >= 0; i--)
                    {
                        Console.WriteLine();
                            var tttffff = matrix[i].Reverse().ToString();
                    }
                    break;
                case 270:
                    break;
            }
            //Console.WriteLine("Rotate(810)".Replace("Rotate(", string.Empty).Replace(")", string.Empty));
        }
    }
}
