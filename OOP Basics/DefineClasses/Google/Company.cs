using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    public class Company
    {
        public Company(string name, string department, double salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return $"{Name} {Department} {Salary:F2}";
        }
    }
}
