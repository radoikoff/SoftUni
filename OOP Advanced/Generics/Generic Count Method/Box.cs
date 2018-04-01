using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethod
{
    public class Box<T> where T : IComparable
    {
        public Box()
        {
            this.Elements = new List<T>();
        }

        public Box(T input)
           : base()
        {
            this.Value = input;

        }

        public T Value { get; private set; }

        public List<T> Elements { get; set; }


        public int EqualsCount(T element)
        {
            return this.Elements.Count(t => t.CompareTo(element) > 0);
        }

        public override string ToString()
        {
            return Value.GetType().FullName;
        }
    }
}
