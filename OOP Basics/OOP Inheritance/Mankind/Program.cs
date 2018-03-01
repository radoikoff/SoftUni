using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    public static void Main()
    {
        var studentData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        var workerData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        try
        {
            var studentFirstName = studentData[0];
            var studentlastName = studentData[1];
            var facilityNumber = studentData[2];

            var student = new Student(studentFirstName, studentlastName, facilityNumber);

            var firstName = workerData[0];
            var lastName = workerData[1];
            var weekSalary = decimal.Parse(workerData[2]);
            var workHoursPerDay = decimal.Parse(workerData[3]);

            var worker = new Worker(firstName, lastName, weekSalary, workHoursPerDay);

            Console.WriteLine(student);
            Console.WriteLine(worker);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}

