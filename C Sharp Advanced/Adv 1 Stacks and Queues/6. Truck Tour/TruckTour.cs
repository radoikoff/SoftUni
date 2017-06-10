using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Truck_Tour
{
    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            long startPump = 0;
            long fuelLeft = 0;

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().Select(long.Parse).ToArray();
                var fuel = tokens[0];
                var distance = tokens[1];

                fuelLeft += fuel;

                if (fuelLeft >= distance)
                {
                    fuelLeft -= distance;
                }
                else
                {
                    startPump = i + 1;
                    fuelLeft = 0;
                }
            }
            Console.WriteLine(startPump);
        }
    }
}
