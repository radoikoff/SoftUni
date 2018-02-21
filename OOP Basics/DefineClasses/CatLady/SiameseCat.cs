using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatLady
{
    public class SiameseCat : Cat
    {
        public SiameseCat(string name, int earSize)
            : base(name)
        {
            EarSize = earSize;
        }

        public int EarSize { get; set; }

        public override string ToString()
        {
            return $"Siamese {Name} {EarSize}";
        }
    }
}
