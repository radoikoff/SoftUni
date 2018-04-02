using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        public ListyIterator(IEnumerable<T> collection)
        {
            this.collection = new List<T>(collection);
            currIndex = 0;
        }

        private List<T> collection;
        private int currIndex;

        public bool Move()
        {
            if (!this.HasNext()) return false;
            this.currIndex++;
            return true;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException($"Invalid Operation!");
            }
            Console.WriteLine(collection[currIndex]);
        }

        public bool HasNext()
        {
            return currIndex < collection.Count - 1;
        }
    }
}
