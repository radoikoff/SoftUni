using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemSplit.Entities.Hardware;
using SystemSplit.Entities.Software;

namespace SystemSplit.Core
{
    public class SystemManager
    {
        private Dictionary<string, List<Software>> softwareList;
        private List<Hardware> hardwareList;

        public SystemManager()
        {
            this.softwareList = new Dictionary<string, List<Software>>();
            this.hardwareList = new List<Hardware>();
        }

        public void RegisterHardware(string name, string type, uint capacity, uint memory)
        {
            if (type == "Power")
            {
                hardwareList.Add(new PowerHardware(name, type, capacity, memory));
            }
            else if (type == "Heavy")
            {
                hardwareList.Add(new HeavyHardware(name, type, capacity, memory));
            }
            softwareList.Add(name, new List<Software>());
        }

        public void RegisterSoftware(string hardwareComponentName, string name, string type, uint capacity, uint memory)
        {
            if (hardwareList.Any(h => h.Name.Equals(hardwareComponentName)))
            {
                var hardwareMaxCapacity = hardwareList.First(h => h.Name.Equals(hardwareComponentName)).MaximumCapacity;
                var hardwareConsumedCapacity = softwareList[hardwareComponentName].Sum(s => s.CapacityConsumption);
                var freeHwCapacity = hardwareMaxCapacity - hardwareConsumedCapacity;

                var hardwareMaxMemory = hardwareList.First(h => h.Name.Equals(hardwareComponentName)).MaximumMemory;
                var hardwareConsumedMemory = softwareList[hardwareComponentName].Sum(s => s.CapacityConsumption);
                var freeHwMemory = hardwareMaxMemory - hardwareConsumedMemory;

                if (freeHwCapacity >= capacity && freeHwMemory >= memory)
                {
                    if (type == "Express")
                    {
                        softwareList[hardwareComponentName].Add(new ExpressSoftware(name, type, capacity, memory));
                    }
                    else if (type == "Light")
                    {
                        softwareList[hardwareComponentName].Add(new LightSoftware(name, type, capacity, memory));
                    }
                }
            }

        }

        public void ReleaseSoftwareComponent(string hardwareComponentName, string softwareComponentName)
        {
            if (hardwareList.Any(h => h.Name.Equals(hardwareComponentName)))
            {
                var softwareToRemove = softwareList[hardwareComponentName].FirstOrDefault(s => s.Name.Equals(softwareComponentName));
                if (softwareToRemove != null)
                {
                    softwareList[hardwareComponentName].Remove(softwareToRemove);
                }
            }
        }

        public string Analyze()
        {
            StringBuilder sb = new StringBuilder();
            var countOfHardwareComponents = hardwareList.Count;
            var countOfSoftwareComponents = softwareList.Values.Sum(s => s.Count);
            var maximumMemory = hardwareList.Sum(h => h.MaximumMemory);
            var totalOperationalMemoryInUse = softwareList.Values.SelectMany(s => s).Sum(s => s.MemoryConsumption);
            var maximumCapacity = hardwareList.Sum(h => h.MaximumCapacity);
            var totalCapacityTaken = softwareList.Values.SelectMany(s => s).Sum(s => s.CapacityConsumption);

            sb.AppendLine($"System Analysis");
            sb.AppendLine($"Hardware Components: { countOfHardwareComponents}");
            sb.AppendLine($"Software Components: { countOfSoftwareComponents}");
            sb.AppendLine($"Total Operational Memory: { totalOperationalMemoryInUse} / { maximumMemory}");
            sb.AppendLine($"Total Capacity Taken: { totalCapacityTaken} / { maximumCapacity}");
            return sb.ToString().Trim();
        }

        public string SystemSplit()
        {
            string result = "";
            foreach (var hardwareComponent in hardwareList.Where(h => h.Type.Equals("Power")))
            {
                result = SystemSplitByHardwareComponent(hardwareComponent);
            }
            foreach (var hardwareComponent in hardwareList.Where(h => h.Type.Equals("Heavy")))
            {
                result += SystemSplitByHardwareComponent(hardwareComponent);
            }
            return result;
        }

        private string SystemSplitByHardwareComponent(Hardware hardwareComponent)
        {
            StringBuilder sb = new StringBuilder();

            int countOfExpressSoftwareComponents = 0;
            int countOfLightSoftwareComponents = 0;
            long memoryUsed = 0;
            var maximumMemory = hardwareComponent.MaximumMemory;
            var maximumCapacity = hardwareComponent.MaximumCapacity;
            long capacityUsed = 0;
            string softwareComponentsList = "None";


            if (softwareList.ContainsKey(hardwareComponent.Name))
            {
                var softwareSet = softwareList.FirstOrDefault(s => s.Key.Equals(hardwareComponent.Name)).Value;
                countOfExpressSoftwareComponents = softwareSet.Count(s => s.Type.Equals("Express"));
                countOfLightSoftwareComponents = softwareSet.Count(s => s.Type.Equals("Light"));
                memoryUsed = softwareSet.Sum(s => s.MemoryConsumption);
                capacityUsed = softwareSet.Sum(s => s.CapacityConsumption);
                softwareComponentsList = string.Join(", ", softwareSet.Select(s => s.Name));


            }

            sb.AppendLine($"Hardware Component – {hardwareComponent.Name}");
            sb.AppendLine($"Express Software Components: { countOfExpressSoftwareComponents}");
            sb.AppendLine($"Light Software Components: { countOfLightSoftwareComponents}");
            sb.AppendLine($"Memory Usage: { memoryUsed} / { maximumMemory}");
            sb.AppendLine($"Capacity Usage: { capacityUsed} / { maximumCapacity}");
            sb.AppendLine($"Type: { hardwareComponent.Type}");
            sb.AppendLine($"Software Components: { softwareComponentsList}");

            return sb.ToString();
        }

    }
}
