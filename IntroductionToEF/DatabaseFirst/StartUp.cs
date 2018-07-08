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
                var projects = context.Projects
                                      .OrderByDescending(p => p.StartDate)
                                      .Take(10)
                                      .OrderBy(p => p.Name)
                                      .ToArray();


                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var e in projects)
                    {
                        sw.WriteLine(e.Name);
                    
                        sw.WriteLine(e.Description);

                        sw.WriteLine(e.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                    }

                }
            }
        }
    }

}






