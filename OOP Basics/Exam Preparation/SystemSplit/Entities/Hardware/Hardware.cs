using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemSplit.Entities.Hardware
{
    public abstract class Hardware
    {
        private string name;
        private string type;
        private uint maximumCapacity;
        private uint maximumMemory;

        protected Hardware(string name, string type, uint maximumCapacity, uint maximumMemory)
        {
            this.Name = name;
            this.Type = type;
            this.MaximumCapacity = maximumCapacity;
            this.MaximumMemory = maximumMemory;
        }

        public uint MaximumMemory
        {
            get { return maximumMemory; }
            protected set { maximumMemory = value; }
        }


        public uint MaximumCapacity
        {
            get { return maximumCapacity; }
            protected set { maximumCapacity = value; }
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
