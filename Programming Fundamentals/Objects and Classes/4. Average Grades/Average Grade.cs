using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Average_Grades
{
    public class Program
    {
        public static void Main()
        {
            var students = new List<Student>();
            int studentsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentsCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                string name = tokens[0];
                var grades = new List<double>();
                for (int j = 1; j < tokens.Length; j++)
                {
                    grades.Add(double.Parse(tokens[j]));
                }
                var currentStudent = new Student();
                currentStudent.Name = name;
                currentStudent.Grades = grades;

                students.Add(currentStudent);
            }

            foreach (var student in students.Where(x=>x.AverageGrade >=5).OrderBy (x=>x.Name).ThenByDescending(x=>x.AverageGrade))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrade:F2}");
            }
        }
    }
}
