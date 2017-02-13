using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StudentGroups
{
    public class StudentGroups
    {
        public static void Main()
        {
            var townList = ReadTownsAndStudents();
            var groups = DistributeStudentsIntoGroups(townList);
            Console.WriteLine($"Created {groups.Count} groups in {groups.Select(x=>x.Town).Distinct().Count()} towns:");
            foreach (var group in groups.OrderBy(x=>x.Town.Name))
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", group.Students.Select(x => x.Email))}");
            }

        }

        public static List<Town> ReadTownsAndStudents()
        {
            var towns = new List<Town>();
            var input = Console.ReadLine();
            while (input != "End")
            {
                if (input.Contains("=>"))
                {
                    var tokens = input.Split(new char[] { '=', '>' }, StringSplitOptions.RemoveEmptyEntries);
                    string townName = tokens[0].Trim();
                    int seatsCount = int.Parse(tokens[1].Replace("seats", string.Empty).Trim());
                    var currentTown = new Town
                    {
                        Name = townName,
                        SeatsCount = seatsCount,
                        Students = new List<Student>()
                    };
                    towns.Add(currentTown);
                }
                else
                {
                    var tokens = input.Split('|');
                    string studentName = tokens[0].Trim();
                    string studentEmail = tokens[1].Trim();
                    DateTime regDate = DateTime.ParseExact(tokens[2].Trim(), "d-MMM-yyyy", CultureInfo.InvariantCulture);
                    var currentStudent = new Student
                    {
                        Name = studentName,
                        Email = studentEmail,
                        RegistrationDate = regDate
                    };
                    towns.Last().Students.Add(currentStudent);
                }
                input = Console.ReadLine();
            }
            return towns;
        }

        public static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            var groups = new List<Group>();
            foreach (var town in towns.OrderBy(x => x.Name))
            {
                var currentStudents = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();
                while (currentStudents.Count!=0)
                {
                    var group = new Group();
                    group.Town = town;
                    group.Students = currentStudents.Take(group.Town.SeatsCount).ToList();
                    currentStudents = currentStudents.Skip(group.Town.SeatsCount).ToList();
                    groups.Add(group);
                }
            }
            return groups;
        }
    }


    public class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    public class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    public class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
