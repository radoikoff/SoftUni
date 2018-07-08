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

                var departments = context.Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                        Emploees = d.Employees.Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        })
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                    })
                    .ToArray();




                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var d in departments)
                    {
                        sw.WriteLine($"{d.DepartmentName} - {d.ManagerName}");

                        foreach (var e in d.Emploees)
                        {
                            sw.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");

                        }
                        sw.WriteLine(new string('-', 10));

                    }
                }
            }
        }

    }
}






