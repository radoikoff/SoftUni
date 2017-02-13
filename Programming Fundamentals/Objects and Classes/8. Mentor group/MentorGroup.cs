using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

public class Student
{
    public string Name { get; set; }
    public List<DateTime> AttendanceDates { get; set; }
    public List<string> Comments { get; set; }
}

namespace _8.Mentor_groups
{
    public class MentorGroup
    {
        public static void Main()
        {
            var students = new SortedDictionary<string, Student>();

            var input = Console.ReadLine();
            while (input != "end of dates")
            {
                var tokens = input.Split();
                var studentName = tokens[0];
                
                var studentDates = new List<DateTime>();
                if (tokens.Length > 1)
                {
                    studentDates = tokens[1].Split(',').Select(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToList();
                }

                if (!students.ContainsKey(studentName))
                {
                    students[studentName] = new Student();
                    students[studentName].Name = studentName;
                    students[studentName].AttendanceDates = new List<DateTime>();
                    students[studentName].AttendanceDates.AddRange(studentDates);
                    students[studentName].Comments = new List<string>();
                }
                else
                {
                    students[studentName].AttendanceDates.AddRange(studentDates);
                }
                
                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "end of comments")
            {
                var tokens = input.Split('-');
                var studentName = tokens[0];
                var studentComments = tokens[1];

                if (students.ContainsKey(studentName) && studentComments != string.Empty)
                {
                    students[studentName].Comments.Add(studentComments);
                }

                input = Console.ReadLine();
            }

            foreach (var student in students)
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");
                foreach (var comment in student.Value.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Value.AttendanceDates.OrderBy(x => x.Date))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }
    }
}
