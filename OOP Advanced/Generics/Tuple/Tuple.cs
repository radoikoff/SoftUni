using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T1, T2>
    {
        public T1 FirstItem { get; private set; }
        public T2 SecondItem { get; private set; }

        public Tuple(T1 firstItem, T2 secondItem)
        {
            this.FirstItem = firstItem;
            this.SecondItem = secondItem;
        }
    }
}
