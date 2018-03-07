using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    public class Child
    {
        public Child(string name, string birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }

        public string Name { get; set; }
        public string BirthDay { get; set; }

        public override string ToString()
        {
            return $"{Name} {BirthDay}";
        }
    }
}
