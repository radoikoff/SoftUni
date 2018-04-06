using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseProject
{
    public class Database
    {
        private const int DefaultCapacity = 16;

        private int[] values;
        private int currentIndex;

        private Database()
        {
            this.values = new int[16];
            this.currentIndex = 0;
        }

        public Database(params int[] values)
            : this()
        {
            this.InitializeValues(values);
        }

        private void InitializeValues(int[] inputValues)
        {
            try
            {
                Array.Copy(inputValues, this.values, inputValues.Length);
                currentIndex = inputValues.Length;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Cannot add another element. Array is full.", ex);
            }

        }

        public void Add(int element)
        {
            if (currentIndex >= DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add another element. Array is full.");
            }
            this.values[currentIndex] = element;
            currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }
            currentIndex--;
            this.values[currentIndex] = 0;
        }

        public int[] Fetch()
        {
            int[] result = new int[currentIndex];
            Array.Copy(this.values, result, currentIndex);

            return result;
        }
    }
}
