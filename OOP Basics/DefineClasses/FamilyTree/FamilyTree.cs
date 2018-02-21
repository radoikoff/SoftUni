using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class FamilyTree
    {
        public static void Main()
        {
            var people = new List<Person>();
            //var ties = new Dictionary<string, string>();
            var ties = new Queue<string>();


            var targetPersonData = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input.Contains(" - "))
                {
                    ties.Enqueue(input);
                }
                else
                {
                    //person mode
                    var tokens = input.Split();
                    var firstName = tokens[0].Trim();
                    var lastName = tokens[1].Trim();
                    var date = tokens[2].Trim();
                    people.Add(new Person(firstName, lastName, date));
                }
            }

            Person person = GetTargetPerson(targetPersonData, people);

            //tie handling
            while (ties.Count != 0)
            {
                var tie = ties.Dequeue();
                var tokens = tie.Split('-');
                var parentData = tokens[0].Trim();
                var childData = tokens[1].Trim();

                var parent = GetTargetPerson(parentData, people);
                if (parent != null && parent.Equals(person))
                {
                    //search for match in parents
                    var child = GetTargetPerson(childData, people);
                    person.Children.Add(child);
                }
                else
                {
                    //search for match in childrens
                    var child = GetTargetPerson(childData, people);
                    if (child != null && child.Equals(person))
                    {
                        person.Parents.Add(parent);
                    }
                }
            }

            Console.WriteLine(person.ToString());
        }

        private static Person GetTargetPerson(string targetPersonData, List<Person> people)
        {
            if (targetPersonData.Contains($"/"))
            {
                //date
                return people.FirstOrDefault(p => p.BirthDate == targetPersonData);
            }
            else
            {
                //names
                var tokens = targetPersonData.Split();
                return people.FirstOrDefault(p => p.FirstName == tokens[0] && p.LastName == tokens[1]);
            }
        }
    }
}
