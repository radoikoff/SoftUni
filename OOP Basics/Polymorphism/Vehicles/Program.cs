using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    static void Main()
    {
        var data = Console.ReadLine().Split().ToArray();
        var car = new Car(double.Parse(data[1]), double.Parse(data[2]), int.Parse(data[3]));

        data = Console.ReadLine().Split().ToArray();
        var truck = new Truck(double.Parse(data[1]), double.Parse(data[2]), int.Parse(data[3]));

        data = Console.ReadLine().Split().ToArray();
        var bus = new Bus(double.Parse(data[1]), double.Parse(data[2]), int.Parse(data[3]));


        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int counter = 0; counter < numberOfCommands; counter++)
        {
            var cmdArgs = Console.ReadLine().Split().ToArray();
            var command = cmdArgs[0].ToLower();
            var vehicleType = cmdArgs[1].ToLower();

            try
            {
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
                        else if (vehicleType == "bus")
                        {
                            Console.WriteLine(bus.Drive(distance));
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
                        else if (vehicleType == "bus")
                        {
                            bus.Refuel(fuelAmount);
                        }
                        break;
                    case "driveempty":
                        distance = double.Parse(cmdArgs[2]);
                        Console.WriteLine(bus.DriveEmpty(distance));
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        Console.WriteLine(car.ToString());
        Console.WriteLine(truck.ToString());
        Console.WriteLine(bus.ToString());

    }
}

