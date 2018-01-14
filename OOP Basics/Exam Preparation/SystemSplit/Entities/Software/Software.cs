using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Entities.Software
{
    public abstract class Software
    {
        private string name;
        private string type;
        private uint capacityConsumption;
        private uint memoryConsumption;

        protected Software(string name, string type, uint capacityConsumption, uint memoryConsumption)
        {
            this.Name = name;
            this.Type = type;
            this.CapacityConsumption = capacityConsumption;
            this.MemoryConsumption = memoryConsumption;
        }

        public uint MemoryConsumption
        {
            get { return memoryConsumption; }
            protected set { memoryConsumption = value; }
        }


        public uint CapacityConsumption
        {
            get { return capacityConsumption; }
            protected set { capacityConsumption = value; }
        }


        public string Type
        {
            get { return type; }
            private set { type = value; }
        }


        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

    }
}
