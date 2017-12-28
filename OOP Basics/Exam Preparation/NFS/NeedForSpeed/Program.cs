using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var manager = new CarManager();

        string input = Console.ReadLine();
        while (input != "Cops Are Here")
        {
            var cmdArgs = input.Split(' ');

            int id;
            string type;

            switch (cmdArgs[0])
            {

                case "register":
                    id = int.Parse(cmdArgs[1]);
                    type = cmdArgs[2];
                    string brand = cmdArgs[3];
                    string model = cmdArgs[4];
                    int yearOfProduction = int.Parse(cmdArgs[5]);
                    int horsepower = int.Parse(cmdArgs[6]);
                    int acceleration = int.Parse(cmdArgs[7]);
                    int suspension = int.Parse(cmdArgs[8]);
                    int durability = int.Parse(cmdArgs[9]);
                    manager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;
                case "check":
                    id = int.Parse(cmdArgs[1]);
                    Console.WriteLine(manager.Check(id));
                    break;
                case "open":
                    id = int.Parse(cmdArgs[1]);
                    type = cmdArgs[2];
                    int length = int.Parse(cmdArgs[3]);
                    string route = cmdArgs[4];
                    int prizePool = int.Parse(cmdArgs[5]);
                    if (cmdArgs.Length>5)
                    {
                        int extraArg = int.Parse(cmdArgs[6]);
                        manager.Open(id, type, length, route, prizePool, extraArg);
                    }
                    else
                    {
                        manager.Open(id, type, length, route, prizePool);
                    }
                    
                    
                    break;
                case "participate":
                    int carId = int.Parse(cmdArgs[1]);
                    int raceId = int.Parse(cmdArgs[2]);
                    manager.Participate(carId, raceId);
                    break;
                case "start":
                    id = int.Parse(cmdArgs[1]);
                    Console.WriteLine(manager.Start(id));
                    break;
                case "park":
                    id = int.Parse(cmdArgs[1]);
                    manager.Park(id);
                    break;
                case "unpark":
                    id = int.Parse(cmdArgs[1]);
                    manager.Unpark(id);
                    break;
                case "tune":
                    int tuneIndex = int.Parse(cmdArgs[1]);
                    string addOn = cmdArgs[2];
                    manager.Tune(tuneIndex, addOn);
                    break;
            }

            input = Console.ReadLine();
        }


    }
}
