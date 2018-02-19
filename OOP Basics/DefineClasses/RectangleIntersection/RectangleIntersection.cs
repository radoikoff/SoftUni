using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleIntersection
{
    public class RectangleIntersection
    {
        public static void Main()
        {
            var rectangles = new List<Rectangle>();
            var input = Console.ReadLine().Split();
            var numberOfRectangles = int.Parse(input[0]);
            var numberOfChecks = int.Parse(input[1]);

            for (int counter = 0; counter < numberOfRectangles; counter++)
            {
                var tokens = Console.ReadLine().Split();
                var id = tokens[0];
                var width = double.Parse(tokens[1]);
                var height = double.Parse(tokens[2]);
                var leftCoordinate = double.Parse(tokens[3]);
                var topCoordinate = double.Parse(tokens[4]);
                rectangles.Add(new Rectangle(id, width, height, leftCoordinate, topCoordinate));
            }

            for (int counter = 0; counter < numberOfChecks; counter++)
            {
                var tokens = Console.ReadLine().Split();
                var rectangleOneId = tokens[0];
                var rectangleTwoId = tokens[1];
                var secondRectangle = rectangles.FirstOrDefault(r => r.Id.Equals(rectangleTwoId));
                var firstRectangle = rectangles.FirstOrDefault(r => r.Id.Equals(rectangleOneId));

                Console.WriteLine(firstRectangle.IsIntersect(secondRectangle).ToString().ToLower());
            }

        }
    }
}
