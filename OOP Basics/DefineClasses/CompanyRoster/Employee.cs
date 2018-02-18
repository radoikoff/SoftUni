using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
            this.age = -1;
            this.email = "n/a";
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
            : this(name, salary, position, department)
        {
            this.Email = email;
            this.Age = age;
        }

        public Employee(string name, decimal salary, string position, string department, string email)
            : this(name, salary, position, department)
        {
            this.Email = email;
            this.age = -1;
        }

        public Employee(string name, decimal salary, string position, string department, int age)
            : this(name, salary, position, department)
        {
            this.Age = age;
            this.email = "n/a";
        }



        public int Age
        {
            get { return age; }
            set { age = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public string Department
        {
            get { return department; }
            set { department = value; }
        }


        public string Position
        {
            get { return position; }
            set { position = value; }
        }


        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"{Name} {Salary:F2} {email} {age}";
        }

    }
}
