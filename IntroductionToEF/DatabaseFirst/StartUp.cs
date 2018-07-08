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
              
                var employees = context.Employees
                                      .Where(e => e.FirstName.StartsWith("sa"))
                                      .Select(e => new
                                      {
                                          e.FirstName,
                                          e.LastName,
                                          e.JobTitle,
                                          e.Salary
                                      })
                                      .OrderBy(e => e.FirstName)
                                      .ThenBy(e => e.LastName)
                                      .ToArray();

                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {

                    foreach (var e in employees)
                    {

                        sw.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
                    }

                }
            }
        }
    }

}






