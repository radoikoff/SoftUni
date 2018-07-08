using P02_DatabaseFirst.Data;
using System.Linq;
using System;
using System.IO;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main()
        {
            using (var context = new SoftUniContext())
            {
                var emploees = context.Employees
                    .Where(e=>e.Salary>50000)
                    .Select(e=>e.FirstName)
                    .OrderBy(e => e)
                    .ToList();

                using (StreamWriter sw = new StreamWriter("../Result.txt"))
                {
                    foreach (var e in emploees)
                    {
                        sw.WriteLine(e);
                    }
                }


            }


        }
    }
}
