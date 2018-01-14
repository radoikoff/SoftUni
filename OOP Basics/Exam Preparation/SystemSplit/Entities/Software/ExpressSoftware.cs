using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Entities.Software
{
    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string name, string type, uint capacityConsumption, uint memoryConsumption)
            : base(name, type, capacityConsumption, memoryConsumption)
        {
            base.MemoryConsumption *= 2;
        }
    }
}
