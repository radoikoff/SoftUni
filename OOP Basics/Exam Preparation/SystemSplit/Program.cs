using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SystemSplit.Core;

namespace SystemSplit
{
    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"(\w+)\((.*)\)";
            var manager = new SystemManager();

            while (input.Trim() != "System Split")
            {
                var regex = new Regex(pattern);
                var match = regex.Match(input);
                if (match.Success)
                {
                    string command = match.Groups[1].Value.Trim();
                    string[] cmdArgs = match.Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    string name;
                    uint capacity;
                    uint memory;
                    string hardwareComponentName;

                    switch (command)
                    {
                        case "RegisterPowerHardware":
                            name = cmdArgs[0].Trim();
                            capacity = uint.Parse(cmdArgs[1].Trim());
                            memory = uint.Parse(cmdArgs[2].Trim());
                            manager.RegisterHardware(name, "Power", capacity, memory);
                            break;

                        case "RegisterHeavyHardware":
                            name = cmdArgs[0].Trim();
                            capacity = uint.Parse(cmdArgs[1].Trim());
                            memory = uint.Parse(cmdArgs[2].Trim());
                            manager.RegisterHardware(name, "Heavy", capacity, memory);
                            break;

                        case "RegisterExpressSoftware":
                            hardwareComponentName = cmdArgs[0].Trim();
                            name = cmdArgs[1].Trim();
                            capacity = uint.Parse(cmdArgs[2].Trim());
                            memory = uint.Parse(cmdArgs[3].Trim());
                            manager.RegisterSoftware(hardwareComponentName, name, "Express", capacity, memory);
                            break;

                        case "RegisterLightSoftware":
                            hardwareComponentName = cmdArgs[0].Trim();
                            name = cmdArgs[1].Trim();
                            capacity = uint.Parse(cmdArgs[2].Trim());
                            memory = uint.Parse(cmdArgs[3].Trim());
                            manager.RegisterSoftware(hardwareComponentName, name, "Light", capacity, memory);
                            break;

                        case "ReleaseSoftwareComponent":
                            hardwareComponentName = cmdArgs[0].Trim();
                            string softwareComponentName = cmdArgs[1].Trim();
                            manager.ReleaseSoftwareComponent(hardwareComponentName, softwareComponentName);
                            break;

                        case "Analyze":
                            Console.WriteLine(manager.Analyze());
                            break;
                    }
                }

                input = Console.ReadLine();
            }
            //system split command
            Console.WriteLine(manager.SystemSplit());
        }
    }
}


