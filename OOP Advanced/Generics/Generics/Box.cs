using System;
using System.Collections.Generic;
using System.Text;

namespace Generics
{
    public class Box<T>
    {
        public Box(T input)
        {
            this.Value = input;
        }

        public T Value { get; private set; }

        public override string ToString()
        {
            return Value.GetType().FullName;
        }
    }
}
