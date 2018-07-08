using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.IO;
using P02_DatabaseFirst.Data.Models;
using System.Globalization;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                string[] departments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

                var employees = context.Employees
                                      .Where(e => departments.Any(d => d == e.Department.Name))
                                      .OrderBy(e => e.FirstName)
                                      .ThenBy(e => e.LastName)
                                      .ToArray();

                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {

                    foreach (var e in employees)
                    {
                        e.Salary *= 1.12m;
                        sw.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
                    }

                }

                context.SaveChanges();
            }
        }
    }

}






