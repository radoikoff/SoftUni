using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatLady
{
    public class StreetExtraordinaireCat : Cat
    {
        public StreetExtraordinaireCat(string name, int decibelsOfMeows)
            : base(name)
        {
            DecibelsOfMeows = decibelsOfMeows;
        }

        public int DecibelsOfMeows { get; set; }

        public override string ToString()
        {
            return $"StreetExtraordinaire {Name} {DecibelsOfMeows}";
        }
    }
}
