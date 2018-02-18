using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class SpeedRacing
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var number = int.Parse(Console.ReadLine());
            for (int counter = 0; counter < number; counter++)
            {
                var carData = Console.ReadLine().Split();
                cars.Add(new Car(carData[0], double.Parse(carData[1]), double.Parse(carData[2])));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandSplit = command.Split();
                var carModel = commandSplit[1];
                var distanceToTravel = int.Parse(commandSplit[2]);

                var car = cars.FirstOrDefault(c => c.Model == carModel);
                if (car.CanCarMove(distanceToTravel))
                {
                    car.DistanceTravelled += distanceToTravel;
                    car.FuelAmount -= distanceToTravel * car.FuelConsumptionPerKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
