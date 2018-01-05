using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {

        DraftManager manager = new DraftManager();
        bool isRunning = true;

        while (isRunning)
        {
            var input = Console.ReadLine().Split(' ');
            string command = input[0];
            var cmdArgs = input.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(cmdArgs));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(cmdArgs));
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(manager.Mode(cmdArgs));
                    break;
                case "Check":
                    Console.WriteLine(manager.Check(cmdArgs));
                    break;
                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    isRunning = false;
                    break;
            }


        }

    }
}

