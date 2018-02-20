using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google
{
    public class Google
    {
        public static void Main()
        {
            var people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var name = tokens[0];

                bool isNewPerson = false;
                var person = people.FirstOrDefault(p => p.Name == name);
                if (person == null)
                {
                    person = new Person(name);
                    isNewPerson = true;
                }

                var dataType = tokens[1];
                switch (dataType)
                {
                    case "company":
                        var companyName = tokens[2];
                        var department = tokens[3];
                        var salary = double.Parse(tokens[4]);
                        person.Company = new Company(companyName, department, salary);
                        break;
                    case "pokemon":
                        var pokemonName = tokens[2];
                        var pokemonType = tokens[3];
                        person.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                        break;
                    case "parents":
                        var parentName = tokens[2];
                        var parentBirthDay = tokens[3];
                        person.Parents.Add(new Parent(parentName, parentBirthDay));
                        break;
                    case "children":
                        var childName = tokens[2];
                        var childBirthDay = tokens[3];
                        person.Children.Add(new Child(childName, childBirthDay));
                        break;
                    case "car":
                        var model = tokens[2];
                        var speed = int.Parse(tokens[3]);
                        person.Car = new Car(model, speed);
                        break;
                }

                if (isNewPerson)
                {
                    people.Add(person);
                }

            }

            var reportName = Console.ReadLine();
            Console.WriteLine(people.FirstOrDefault(p => p.Name == reportName).ToString());

        }
    }
}
