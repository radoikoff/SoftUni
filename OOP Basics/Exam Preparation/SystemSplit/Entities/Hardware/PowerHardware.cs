using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Entities.Hardware
{
    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, string type, uint maximumCapacity, uint maximumMemory)
            : base(name, type, maximumCapacity, maximumMemory)
        {
            base.MaximumCapacity -= maximumCapacity * 75 / 100;
            base.MaximumMemory += maximumMemory * 75 / 100;
        }
    }
}
