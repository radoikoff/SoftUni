using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main()
    {
        var carData = Console.ReadLine().Split().ToArray();
        var car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));

        var truckData = Console.ReadLine().Split().ToArray();
        var truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int counter = 0; counter < numberOfCommands; counter++)
        {
            var cmdArgs = Console.ReadLine().Split().ToArray();
            var command = cmdArgs[0].ToLower();
            var vehicleType = cmdArgs[1].ToLower();

            switch (command)
            {
                case "drive":
                    var distance = double.Parse(cmdArgs[2]);
                    if (vehicleType == "car")
                    {
                        Console.WriteLine(car.Drive(distance));
                    }
                    else if (vehicleType == "truck")
                    {
                        Console.WriteLine(truck.Drive(distance));
                    }
                    break;
                case "refuel":
                    var fuelAmount = double.Parse(cmdArgs[2]);
                    if (vehicleType == "car")
                    {
                        car.Refuel(fuelAmount);
                    }
                    else if (vehicleType == "truck")
                    {
                        truck.Refuel(fuelAmount);
                    }
                    break;
            }
        }

        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());

    }
}

