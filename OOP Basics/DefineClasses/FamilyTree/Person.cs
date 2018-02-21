using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class Person : IEquatable<Person>
    {
        public Person(string firstName, string lastName, string birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Parents = new List<Person>();
            Children = new List<Person>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        public bool Equals(Person other)
        { 
            if (this.FirstName != other.FirstName) return false;
            if (this.LastName != other.LastName) return false;
            if (this.BirthDate != other.BirthDate) return false;

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{FirstName} {LastName} {BirthDate}");
            sb.AppendLine("Parents:");
            foreach (var parent in Parents)
            {
                sb.AppendLine($"{parent.FirstName} {parent.LastName} {parent.BirthDate}");
            }
            sb.AppendLine("Children:");
            foreach (var child in Children)
            {
                sb.AppendLine($"{child.FirstName} {child.LastName} {child.BirthDate}");
            }

            return sb.ToString();
        }
    }
}
