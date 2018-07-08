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
                var projects = context.EmployeesProjects.Where(p => p.ProjectId == 2);
                context.EmployeesProjects.RemoveRange(projects);

                var project = context.Projects.Find(2);
                context.Projects.Remove(project);

                context.SaveChanges();

                var projectList = context.Projects.Take(10).ToArray();

                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var e in projectList)
                    {
                        sw.WriteLine(e.Name);
                    }

                }
            }
        }
    }

}






