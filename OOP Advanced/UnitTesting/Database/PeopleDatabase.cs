using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseProject
{
    public class PeopleDatabase
    {
        private const int DefaultCapacity = 16;

        private Person[] people;
        private int currentIndex;

        private PeopleDatabase()
        {
            this.people = new Person[16];
            this.currentIndex = 0;
        }

        public PeopleDatabase(params Person[] values)
            : this()
        {
            this.InitializeValues(values);
        }

        private void InitializeValues(Person[] inputValues)
        {
            try
            {
                Array.Copy(inputValues, this.people, inputValues.Length);
                currentIndex = inputValues.Length;
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException("Cannot add another element. Array is full.", ex);
            }

        }

        public void Add(Person person)
        {
            //if (person == null)
            //{
            //    throw new InvalidOperationException("Person to add cannot be null");
            //}

            if (this.people.Any(p => p.Id == person.Id) || this.people.Any(p => p.UserName == person.UserName))
            {
                throw new InvalidOperationException($"Person {person} already exists");
            }

            if (currentIndex >= DefaultCapacity)
            {
                throw new InvalidOperationException("Cannot add another element. Array is full.");
            }
            this.people[currentIndex] = person;
            currentIndex++;
        }

        public void Remove()
        {
            if (currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }
            currentIndex--;
            this.people[currentIndex] = null;
        }

        public int[] Fetch()
        {
            int[] result = new int[currentIndex];
            Array.Copy(this.people, result, currentIndex);

            return result;
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id cannot be negative!");
            }

            Person person = people.FirstOrDefault(p => p?.Id == id);

            if (person == null)
            {
                throw new InvalidOperationException($"Person with Id {id} does not exsits!");
            }

            return person;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username cannot be null!");
            }

            Person person = people.FirstOrDefault(p => p?.UserName == username);

            if (person == null)
            {
                throw new InvalidOperationException($"Person with username {username} does not exsits!");
            }
            return person;
        }
    }
}
