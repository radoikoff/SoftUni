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

                var emploees = context.Employees.Where(e => e.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                    .Take(30)
                    .Select(e => new
                    {
                        EmploeeName = e.FirstName + " " + e.LastName,
                        ManagerName = e.Manager.FirstName + " " + e.Manager.LastName,
                        Projects = e.EmployeesProjects.Select(p => new
                        {
                            ProjectName = p.Project.Name,
                            StartDate = p.Project.StartDate,
                            EndDate = p.Project.EndDate
                        })
                    })
                    .Take(30)
                    .ToArray();


                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var e in emploees)
                    {
                        sw.WriteLine($"{e.EmploeeName} - Manager: {e.ManagerName}");

                        foreach (var p in e.Projects)
                        {
                            sw.WriteLine($"--{p.ProjectName} - {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {p.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) ?? "not finished"}");
                        }
                    }
                }
            }
        }

    }
}






