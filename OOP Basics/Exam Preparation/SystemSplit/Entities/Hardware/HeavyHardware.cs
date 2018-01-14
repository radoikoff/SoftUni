using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Entities.Hardware
{
    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, string type, uint maximumCapacity, uint maximumMemory)
            : base(name, type, maximumCapacity, maximumMemory)
        {
            base.MaximumCapacity *= 2;
            base.MaximumMemory -= maximumMemory * 25 / 100;
        }
    }
}
