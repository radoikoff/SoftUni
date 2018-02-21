using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatLady
{
    public class CymricCat : Cat
    {
        public CymricCat(string name, double furLength)
            : base(name)
        {
            FurLength = furLength;
        }

        public double FurLength { get; set; }

        public override string ToString()
        {
            return $"Cymric {Name} {FurLength:F2}";
        }
    }
}
