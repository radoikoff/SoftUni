using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Entities.Software
{
    public class LightSoftware : Software
    {
        public LightSoftware(string name, string type, uint capacityConsumption, uint memoryConsumption)
            : base(name, type, capacityConsumption, memoryConsumption)
        {
            base.CapacityConsumption += capacityConsumption * 50 / 100;
            base.MemoryConsumption -= memoryConsumption * 50 / 100;
        }
    }
}
