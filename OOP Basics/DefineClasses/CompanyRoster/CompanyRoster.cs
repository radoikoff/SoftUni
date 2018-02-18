using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
    public class CompanyRoster
    {
        public static void Main()
        {
            var employees = new List<Employee>();
            var number = int.Parse(System.Console.ReadLine());
            for (int counter = 0; counter < number; counter++)
            {
                var data = Console.ReadLine().Split();
                var name = data[0];
                var salary = Decimal.Parse(data[1]);
                var position = data[2];
                var department = data[3];

                if (data.Length == 4)
                {
                    employees.Add(new Employee(name, salary, position, department));
                }
                else if (data.Length == 5)
                {
                    if (data[4].Contains("@"))
                    {
                        var email = data[4];
                        employees.Add(new Employee(name, salary, position, department, email));
                    }
                    else
                    {
                        var age = int.Parse(data[4]);
                        employees.Add(new Employee(name, salary, position, department, age));
                    }
                }
                else if (data.Length == 6)
                {
                    var email = data[4];
                    var age = int.Parse(data[5]);
                    employees.Add(new Employee(name, salary, position, department, email, age));
                }

            }
            var departmentName = employees.GroupBy(e => e.Department)
                                    .Select(g => new { Department = g.Key, Salary = g.Average(e => e.Salary) })
                                    .OrderByDescending(d => d.Salary)
                                    .FirstOrDefault()
                                    .Department;

            Console.WriteLine($"Highest Average Salary: {departmentName}");
            foreach (var employee in employees.Where(e => e.Department == departmentName).OrderByDescending(e => e.Salary))
            {
                Console.WriteLine(employee.ToString());
            }


        }
    }
}
