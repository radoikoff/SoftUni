using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomList
{
    public class CustomList<T> where T : IComparable
    {
        private readonly List<T> items;

        public IReadOnlyCollection<T> Items => this.items.AsReadOnly();

        public CustomList()
        {
            this.items = new List<T>();
        }

        public void Add(T element)
        {
            this.items.Add(element);
        }

        public T Remove(int index)
        {
            T item = this.items[index];
            this.items.RemoveAt(index);
            return item;
        }

        public bool Contains(T element)
        {
            return this.items.Contains(element);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var itemAtFirstPosition = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = itemAtFirstPosition;
        }

        public int CountGreaterThan(T element)
        {
            return this.items.Count(t => t.CompareTo(element) > 0);
        }

        public T Max()
        {
            return this.items.Max();
        }

        public T Min()
        {
            return this.items.Min();
        }
    }
}
