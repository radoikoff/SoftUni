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
                var employee147 = context.Employees.Find(147);
                var projects = context.Projects
                                      .Where(p => p.EmployeesProjects.Any(ep => ep.EmployeeId == 147))
                                      .OrderBy(p=>p.Name);


                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    sw.WriteLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
                    foreach (var e in projects)
                    {
                        sw.WriteLine(e.Name);
                    }

                }
            }
        }
    }

}






