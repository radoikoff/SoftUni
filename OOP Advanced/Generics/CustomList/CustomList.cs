﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> items;

        public CustomList()
        {
            this.items = new List<T>();
        }

        public IList<T> Items => this.items.AsReadOnly();

        public int Count => this.items.Count;

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
            set
            {
                this.items[index] = value;
            }
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

        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
    }
}
